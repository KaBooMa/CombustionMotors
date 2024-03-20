using System;
using System.Collections.Generic;
using CombustionMotors.Behaviours.Bases;
using CombustionMotors.Behaviours.Blocks;
using CombustionMotors.Behaviours.Heads;
using GearLib.API.Fields;
using SmashHammer.GearBlocks.Construction;
using SmashHammer.Input;
using UnityEngine;
using Behaviour = GearLib.API.Behaviour;

namespace CombustionMotors.Behaviours.Interactables;

public class ECUBehaviour : Behaviour
{
    [IntField(label = "Idle RPM Target", tooltip_text = "Target RPMs for idle (May not reach all the time)", initial_value = 400, minimum_value = 0, maximum_value = 2000)]
    public int idle_rpms;

    [IntField(label = "Redline", tooltip_text = "Target RPMs to cut fuel", initial_value = 2000, minimum_value = 0, maximum_value = 30000)]
    public int max_rpms;

    [IntField(label = "(ADVANCED) Redline Buffer", tooltip_text = "How much RPM must drop after redlining to supply fuel again", initial_value = 100, minimum_value = 0, maximum_value = 1000)]
    public int redline_buffer;

    [FloatField(label = "(EXPERIMENTAL) Opposing Force", tooltip_text = "Supplies an inversed force away from piston on fixed attachment", initial_value = 1, minimum_value = 0, maximum_value = 1)]
    public float opposing_force;

    [IntField(label = "Fuel Efficiency", tooltip_text = "How effectively the fuel burns in the cylinder (20-35% gasoline, 40-50% diesel)", initial_value = 20, minimum_value = 0, maximum_value = 100)]
    public int fuel_efficiency;

    [FloatField(label = "Compression Ratio", tooltip_text = "Compression of the engine (Typically 8-12 for gasoline; 14-23 for diesel)", initial_value = 8, minimum_value = 0, maximum_value = 25)]
    public float compression_ratio;

    [JoystickField(label = "Linear Throttle", tooltip_text = "Throttle input via controller")]
    public JoystickAxis throttle_joystick;

    [InputField(label = "Direct Throttle", tooltip_text = "Throttle input via keyboard")]
    public InputAction throttle_keyboard;

    [BooleanField(label = "Two Stroke?", tooltip_text = "Default behavior is 4 stroke. Toggle this for a 2 stroke engine.")]
    public bool two_stroke;

    bool redlined = false;
    bool is_frozen = false;

    List<EngineComponents> attached_blocks = new List<EngineComponents>();
    public AudioClip engine_sound;
    public AudioSource engine_audio_source;

    static float atmospheric_pressure = 14.7f;

    void FixedUpdate()
    {
        // Don't do calculations if construction is frozen currently
        if (GetComponent<PartDescriptor>().ParentConstruction.IsFrozen)
        {
            is_frozen = true;
            return;
        }
        else if (is_frozen)
        {
            // Setup our attached blocks for referencing later
            attached_blocks.Clear();
            foreach (GameObject block in GetLinkedParts("CrankshaftSensors"))
            {
                attached_blocks.Add(new EngineComponents(block));
            }

            // Testing audio clip
            engine_sound = Resources.Load<AudioClip>("CombustionMotors/assets/combustion_motors/engine_4.ogg");
            engine_audio_source = transform.gameObject.AddComponent<AudioSource>();
            engine_audio_source.clip = engine_sound;

            is_frozen = false;
        }

        // If we have no blocks attached, don't do any compute

        foreach (EngineComponents block in attached_blocks)
        {
            // Ignore not fully built engines
            if (!block.IsBuilt) continue;

            PistonBehaviour piston = block.PistonBehaviour;
            HeadBehaviour head = block.HeadBehaviour;
            //CrankshaftBehaviour crankshaft = block.crankshaft.GetComponent<CrankshaftBehaviour>();
            RotaryBearingAttachment crankshaft_bearing = block.CrankshaftBearing;

            // Piston info
            float bore_size = piston.bore_size;
            float timing = head.timing;
            float offset = head.offset;
            bool has_fired = head.has_fired;

            // Crank info
            float crank_angle = crankshaft_bearing.CurrentAngle + crankshaft_bearing.CurrentAngle < 0 ? crankshaft_bearing.CurrentAngle + 360 : crankshaft_bearing.CurrentAngle;
            float current_rpms = Math.Abs(crankshaft_bearing.CurrentAngularSpeed) * 9.935f;

            // Power calculations
            // float displacement = 0.785f * (float)Math.Pow(bore_size, 2) * crankshaft.stroke_length;
            float throttle = Math.Clamp(throttle_joystick.axis.Value + Convert.ToInt32(throttle_keyboard.IsHeld), 0, 1);
            float cylinder_pressure = atmospheric_pressure * compression_ratio * Math.Clamp(throttle, 0.05f * (1 - current_rpms / idle_rpms), 1f);
            float piston_area = (float)(Math.PI * Math.Pow(bore_size / 2, 2)) * 0.0000155f;
            float perfect_force = piston_area * cylinder_pressure * 4.4482216f;
            float applicable_force = perfect_force * fuel_efficiency;

            // Reduce applicable force by displacement to account for friction
            float friction_loss_percentage = piston_area * current_rpms / 10000;
            applicable_force *= 1 - friction_loss_percentage;

            if (current_rpms > max_rpms)
            {
                applicable_force = 0;
                redlined = true;
            }
            if (current_rpms < max_rpms - redline_buffer) redlined = false;

            // Firing angle calculations
            float start_fire = timing + offset;
            float stop_fire = (start_fire + 180 - timing) % 360;

            // Stroke updater
            if (
                (start_fire < 180 && crank_angle >= start_fire && crank_angle <= stop_fire) ||
                (start_fire >= 180 && (crank_angle >= start_fire || crank_angle <= stop_fire))
                )
            {
                if (head.stroke == 4 || head.stroke == 2) head.stroke++;

                if ((!two_stroke && head.stroke >= 5) || (two_stroke && head.stroke >= 3))
                {
                    head.stroke = 1;
                    head.has_fired = false;
                }
            }
            else
            {
                if (head.stroke == 3 || head.stroke == 1) head.stroke++;
            }


            // Firing piston as needed when within the start/stop angle
            if (head.stroke == 1 && !has_fired && !redlined)
            {
                engine_audio_source.PlayOneShot(engine_sound);

                block.PistonRigidbody.AddRelativeForce(-Vector3.up * applicable_force);

                if (opposing_force > 0)
                {
                    block.HeadRigidbody.AddRelativeForce(Vector3.up * applicable_force * opposing_force);
                }

                head.has_fired = true;
            }
            else
            {
                head.has_fired = false;
            }
        }

    }
}