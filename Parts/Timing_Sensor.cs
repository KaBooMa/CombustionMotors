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
            new Vector3(0f, 0f, 0f),
            new Vector3(180f, 0f, 0f)
        );
        AddAttachmentPoint(
            "CrankSensor",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsBidirectional | AlignmentFlags.IsInterior | AlignmentFlags.IsFemale,
            new Vector3(0f, 0.05f, 0f),
            new Vector3(180f, 0f, 0f)
        );

        AddLinkPoint("Pistons", "Combustion", Vector3.zero, can_receive: false);
        AddBehaviour<TimingSensorBehaviour>();
    }
}

public class TimingSensorBehaviour : BehaviourBase 
{
    public IntField timing = new IntField("Timing", "Offset degrees from TDC to fire piston", 5, -30, 30);
    public IntField fire_length = new IntField("Detonation Span", "Degrees span from timing to fire piston", 90, 0, 180);
    public IntField detonation_power_big = new IntField("Detonation Power", "Amount of power to detonate with", 0, 0, 50000);
    public FloatField detonation_power_fine = new FloatField("Detonation Power (Fine Tune)", "Small number fine tuning of power", 0, 0, 100);
    
    // public BooleanField opposing_force = new BooleanField("Opposing Force", "If enabled, will apply detonation to fixed part as well", false);

    void FixedUpdate()
    {
        List<GameObject> attached_pistons = GetLinkedParts("Pistons");
        if (attached_pistons.Count == 0) return;

        float detonation_power = detonation_power_fine + detonation_power_big;

        RotaryBearingAttachment piston_attachment = GetAttachment("CrankSensor").Cast<RotaryBearingAttachment>();
        float crank_angle = piston_attachment.CurrentAngle + piston_attachment.CurrentAngle < 0 ? piston_attachment.CurrentAngle + 360 : piston_attachment.CurrentAngle;
        
        float piston_offset = 360 / attached_pistons.Count;

        int current_piston = 0;
        foreach (GameObject piston in attached_pistons)
        {
            float start_fire = (piston_offset * current_piston) + timing;
            float stop_fire = start_fire + fire_length;

            if (crank_angle >= start_fire && crank_angle <= stop_fire)
            {
                Rigidbody piston_rigid_body = piston.transform.parent.GetComponent<Rigidbody>();
                piston_rigid_body.AddRelativeForce(-Vector3.up * detonation_power);

                //piston_rigid_body.velocity = -piston_rigid_body.transform.up * Time.deltaTime * detonation_power;
                
                // if (opposing_force) 
                // {
                //     FixedAttachment fixed_attachment = GetAttachment("Fixed").Cast<FixedAttachment>();
                //     Rigidbody attached_rigid_body = fixed_attachment.ConnectedPart.parentComposite.GetComponent<Rigidbody>();
                //     attached_rigid_body.velocity = -attached_rigid_body.transform.forward * Time.deltaTime * detonation_power;
                // }
            }
            current_piston++;
        }
    }
}