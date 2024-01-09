using System;
using System.Collections.Generic;
using System.Linq;
using CombustionMotors.Behaviours.Bases;
using CombustionMotors.Utility;
using GearLib.Behaviours;
using GearLib.Behaviours.Fields;
using SmashHammer.GearBlocks.Construction;
using SmashHammer.Input;
using UnityEngine;

namespace CombustionMotors.Behaviours.Interactables;

public class ECUBehaviour : BehaviourBase
{
    #region Engine banks - unity caching

    private class EngineComponents {

        public EngineComponents(BlockTag block)
        {
            BlockUtility = new BlockUtility(block.gameObject);
            Piston = BlockUtility.Piston.GetComponent<PistonBehaviourBase>();
            Head = BlockUtility.Head.GetComponent<HeadBehaviour>();
            Crank = block.GetAttachment("Crankshaft").Cast<RotaryBearingAttachment>();
            PistonBody = Piston.transform.parent.GetComponent<Rigidbody>();
            HeadBody = BlockUtility.Head.parentComposite.GetComponent<Rigidbody>();
        }

        public BlockUtility BlockUtility { get; }
        public PistonBehaviourBase Piston { get; }
        public HeadBehaviour Head { get; }
        public RotaryBearingAttachment Crank { get; }
        public Rigidbody PistonBody { get; set; }
        public Rigidbody HeadBody { get; set; }
    }

    private Dictionary<BlockTag, EngineComponents> engineBanks = [];

    private Construction ParentConstruction;

    #endregion

    private bool redlined = false;
    private bool IsFrozen = false;
    private static float atmospheric_pressure = 14.7f;

    #region Behaviour Configuration

    [IntField(label = "Idle RPM Target", tooltip_text = "Target RPMs for idle (May not reach all the time)", initial_value = 400, minimum_value = 0, maximum_value = 1200)]
    public int idle_rpms;

    [IntField(label = "Redline", tooltip_text = "Target RPMs to cut fuel", initial_value = 2000, minimum_value = 0, maximum_value = 10000)]
    public int max_rpms;

    [IntField(label = "(ADVANCED) Redline Buffer", tooltip_text = "How much RPM must drop after redlining to supply fuel again", initial_value = 100, minimum_value = 0, maximum_value = 1000)]
    public int redline_buffer;

    [FloatField(label = "(EXPERIMENTAL) Opposing Force", tooltip_text = "Supplies an inversed force away from piston on fixed attachment", initial_value = 1, minimum_value = 0, maximum_value = 1)]
    public float opposing_force;

    //[IntField(label = "Fuel Efficiency", tooltip_text = "How effectively the fuel burns in the cylinder (20-35% gasoline, 40-50% diesel)", initial_value = 25, minimum_value = 20, maximum_value = 100)]
    int fuel_efficiency = 20;

    [FloatField(label = "Compression Ratio", tooltip_text = "Compression of the engine (Typically 8-12 for gasoline; 14-23 for diesel)", initial_value = 10, minimum_value = 8, maximum_value = 12)]
    public float compression_ratio;

    [JoystickField(label = "Linear Throttle", tooltip_text = "Throttle input via controller")]
    public JoystickAxis throttle_joystick;

    [InputField(label = "Direct Throttle", tooltip_text = "Throttle input via keyboard")]
    public InputAction throttle_keyboard;

    #endregion

    void Start() {
        ParentConstruction = GetComponent<PartDescriptor>().ParentConstruction;
    }

    void FixedUpdate()
    {
        // Don't do calculations if construction is frozen currently
        if (ParentConstruction.IsFrozen)
        {
            IsFrozen = true;
            return;
        }
        
        // Setup engine once unfrozen
        if (IsFrozen)
        {

            var banks = GetLinkedParts("CrankshaftSensors")
                .Select(s => s.GetComponent<BlockTag>());

            foreach (var bank in banks)
            {
                if (engineBanks.ContainsKey(bank)) {
                    // refresh bank (since engine may have been changed)
                    engineBanks[bank] = new EngineComponents(bank);
                    continue;
                }
                // add bank
                engineBanks.Add(bank, new EngineComponents(bank));
            }

            foreach (var (bank, _) in engineBanks.Reverse()) {
                if (!banks.Contains(bank)) engineBanks.Remove(bank);
            }

            IsFrozen = false;
        }

        // If we have no blocks attached, don't do any compute

        foreach (var (_, bank) in engineBanks)
        {
            // Ignore not fully built engines
            if (!bank.BlockUtility.IsBuilt) continue;

            var piston = bank.Piston;
            var head = bank.Head;
            var crankshaftBearing = bank.Crank;

            // Piston info
            float bore_size = piston.bore_size;
            float timing = head.timing;
            float offset = head.offset;
            bool has_fired = head.has_fired;

            // Crank info
            float crank_angle = crankshaftBearing.CurrentAngle + crankshaftBearing.CurrentAngle < 0 ? crankshaftBearing.CurrentAngle + 360 : crankshaftBearing.CurrentAngle;
            float current_rpms = Math.Abs(crankshaftBearing.CurrentAngularSpeed) * 9.935f;

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

                if (head.stroke == 5) 
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
                bank.PistonBody.AddRelativeForce(-Vector3.up * applicable_force);

                if (opposing_force > 0)
                {
                    bank.HeadBody.AddRelativeForce(Vector3.up * applicable_force * opposing_force);
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