using System;
using System.Collections.Generic;
using GearLib.Behaviours;
using GearLib.Behaviours.Fields;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts;

class Timing_Sensor : Part
{
    public Timing_Sensor() : base("CombustionMotors/assets/combustion_motors", "timing_sensor", 56185557270, "Timing Sensor", "Props", 0.1f)
    {
        AddAttachmentPoint(
            "Fixed",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(0f, -0.05f, 0f),
            new Vector3(180f, 0f, 0f)
        );
        AddAttachmentPoint(
            "CrankSensor",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsBidirectional | AlignmentFlags.IsInterior | AlignmentFlags.IsFemale,
            new Vector3(0f, 0f, 0f),
            new Vector3(180f, 0f, 0f)
        );

        AddLinkPoint("Pistons", "Combustion", Vector3.zero, can_receive: false);
        AddBehaviour<TimingSensorBehaviour>();
    }
}

public class TimingSensorBehaviour : BehaviourBase 
{
    public IntField timing = new IntField("Timing", "Offset degrees from TDC to fire piston", 5, -30, 30);
    public IntField piston_offset = new IntField("Piston Offset", "Offsets the TDC for the piston", 0, 0, 360);
    public FloatField idle_power = new FloatField("Idle Power", "Power to supply during idle", 0, 0, 0.5f);
    public FloatField max_power = new FloatField("Max Power", "Power to supply at full throttle", 0, 0, 1000);
    public JoystickField throttle_joystick = new JoystickField("Linear Throttle", "Throttle input");
    float bore_size = 50f; // mm
    float stroke_length = 63.1f; // mm

    bool has_fired = false;

    void FixedUpdate()
    {
        List<GameObject> attached_pistons = GetLinkedParts("Pistons");
        if (attached_pistons.Count == 0) return;

        float throttle = throttle_joystick.AxisValue;

        int piston_count = 1;
        float displacement = 0.785f * (float)Math.Pow(bore_size, 2) * stroke_length * piston_count;
        float calculated_power = displacement / 1000 * idle_power + ((max_power - idle_power) * throttle);

        GameObject piston = attached_pistons[0];
        RotaryBearingAttachment piston_attachment = GetAttachment("CrankSensor").Cast<RotaryBearingAttachment>();
        float crank_angle = piston_attachment.CurrentAngle + piston_attachment.CurrentAngle < 0 ? piston_attachment.CurrentAngle + 360 : piston_attachment.CurrentAngle;

        float start_fire = timing + piston_offset;
        float stop_fire = (start_fire + 180 - timing) % 360;

        if (!has_fired && crank_angle >= start_fire && crank_angle <= stop_fire)
        {
            Rigidbody piston_rigid_body = piston.transform.parent.GetComponent<Rigidbody>();
            piston_rigid_body.AddRelativeForce(-Vector3.up * calculated_power);
            has_fired = true;
        }
        else
        {
            has_fired = false;
        }
    }
}