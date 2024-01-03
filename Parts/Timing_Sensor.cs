using CombustionMotors.Behaviours;
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