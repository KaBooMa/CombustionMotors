using CombustionMotors.Behaviours.Interactables;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Interactables;

class ECU : Part
{
    public ECU() : base("CombustionMotors/assets/combustion_motors", "ecu", 412621540480970, "ECU", "Electronics", 0.1f, true)
    {
        AddAttachmentPoint(
            "Fixed",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(0f, -0.05f, 0f),
            new Vector3(180f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddLinkPoint("CrankshaftSensors", "Electronics", Vector3.zero, can_receive: false);
        AddBehaviour<ECUBehaviour>();
    }
}