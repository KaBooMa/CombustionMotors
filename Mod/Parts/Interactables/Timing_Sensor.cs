using CombustionMotors.Behaviours.Interactables;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Interactables;

class Timing_Sensor : Part
{
    public Timing_Sensor() : base("CombustionMotors/assets/combustion_motors", "timing_sensor", 56185557270, "Crankshaft Sensor", "Electronics", 0.1f)
    {
        AddAttachmentPoint(
            "Fixed",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(0f, -0.05f, 0f),
            new Vector3(180f, 0f, 0f),
            Vector3Int.one
        );
        AddAttachmentPoint(
            "CrankSensor",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsBidirectional | AlignmentFlags.IsInterior | AlignmentFlags.IsFemale,
            new Vector3(0f, 0f, 0f),
            new Vector3(180f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddLinkPoint("ECU", "Electronics", new Vector3(0, -0.1f, 0), can_send: false);
        AddLinkPoint("Pistons", "Combustion", new Vector3(0, 0.1f, 0), can_receive: false);
        AddBehaviour<TimingSensorBehaviour>();
    }
}