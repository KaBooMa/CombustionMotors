using System;
using System.Collections.Generic;
using CombustionMotors.Parts.Behaviours;
using GearLib.Behaviours;
using GearLib.Behaviours.Fields;
using SmashHammer.GearBlocks.Construction;
using SmashHammer.Input;
using UnityEngine;

namespace CombustionMotors.Behaviours;

public class TimingSensorBehaviour : BehaviourBase 
{
    [IntField(label = "Timing", tooltip_text = "Offset degrees from TDC to fire piston", initial_value = 5, minimum_value = -30, maximum_value = 30)]
    public int timing;

    [IntField(label = "Piston Offset", tooltip_text = "Offsets the TDC for the piston", initial_value = 0, minimum_value = 0, maximum_value = 360)]
    public int piston_offset;

    [IntField(label = "Idle RPM Target", tooltip_text = "Target RPMs for idle (May not reach all the time)", initial_value = 400, minimum_value = 0, maximum_value = 1200)]
    public int idle_rpms;

    [IntField(label = "Redline", tooltip_text = "Target RPMs to cut fuel", initial_value = 2000, minimum_value = 0, maximum_value = 10000)]
    public int max_rpms;

    [IntField(label = "(ADVANCED) Redline Buffer", tooltip_text = "How much RPM must drop after redlining to supply fuel again", initial_value = 100, minimum_value = 0, maximum_value = 1000)]
    public int redline_buffer;

    [BooleanField(label = "(EXPERIMENTAL) Use Opposing Force", tooltip_text = "Supply inverse force away from piston on fixed attachment")]
    public bool using_opposing_force;

    [JoystickField(label = "Linear Throttle", tooltip_text = "Throttle input via controller")]
    public JoystickAxis throttle_joystick;

    [InputField(label = "Direct Throttle", tooltip_text = "Throttle input via keyboard")]
    public InputAction throttle_keyboard;

    public float idle_power = 0.01f;
    public float power = 0.03f;
    float stroke_length = 500f; // mm

    bool has_fired = false;
    bool redlined = false;

    void FixedUpdate()
    {
        // Don't do calculations if construction is frozen currently
        if (GetComponent<PartDescriptor>().ParentConstruction.IsFrozen) return;
        
        List<GameObject> attached_pistons = GetLinkedParts("Pistons");
        if (attached_pistons.Count == 0) return;

        GameObject piston = attached_pistons[0];
        PistonBehaviour piston_behaviour = piston.GetComponent<PistonBehaviour>();
        float bore_size = piston_behaviour.bore_size;
        RotaryBearingAttachment piston_attachment = GetAttachment("CrankSensor").Cast<RotaryBearingAttachment>();
        float crank_angle = piston_attachment.CurrentAngle + piston_attachment.CurrentAngle < 0 ? piston_attachment.CurrentAngle + 360 : piston_attachment.CurrentAngle;


        float throttle = Math.Clamp(throttle_joystick.axis.Value + Convert.ToInt32(throttle_keyboard.IsHeld), 0, 1);

        int piston_count = 1;
        float displacement = 0.785f * (float)Math.Pow(bore_size, 2) * stroke_length * piston_count;
        float power_target = power * throttle;
        float current_rpms = Math.Abs(piston_attachment.CurrentAngularSpeed)*9.935f;

        if (current_rpms > max_rpms) 
        {
            power_target = 0;
            redlined = true;
        }
        if (current_rpms < max_rpms - redline_buffer) redlined = false;
        if (throttle == 0 && current_rpms < idle_rpms) power_target = idle_power * (1 - (current_rpms / idle_rpms));

        float calculated_power = displacement / 1000 * power_target;

        float start_fire = timing + piston_offset;
        float stop_fire = (start_fire + 180 - timing) % 360;

        if (!has_fired && !redlined && (
            (start_fire < 180 && crank_angle >= start_fire && crank_angle <= stop_fire) || 
            (start_fire >= 180 && (crank_angle >= start_fire || crank_angle <= stop_fire))
            ))
        {
            Rigidbody piston_rigid_body = piston.transform.parent.GetComponent<Rigidbody>();
            piston_rigid_body.AddRelativeForce(-Vector3.up * calculated_power);

            if (using_opposing_force)
            {
                FixedAttachment fixed_attachment = GetAttachment("Fixed").Cast<FixedAttachment>();
                Rigidbody fixed_rigid_body = fixed_attachment.ConnectedPart.transform.parent.GetComponent<Rigidbody>();
                fixed_rigid_body.AddRelativeForce(Vector3.up * calculated_power);
            }

            has_fired = true;
        }
        else
        {
            has_fired = false;
        }
    }
}