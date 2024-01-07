using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Interactables;

class Throttle_Base : Part
{
    public Throttle_Base() : base("CombustionMotors/assets/combustion_motors", "throttle_body", 62720565116, "Throttle Base", "Props", 1f, true)
    {
        AddAttachmentPoint(
            "Fixed",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(0f, 0f, 0f),
            new Vector3(180f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "KnuckleOuter",
            AttachmentTypeFlags.KnuckleJoint,
            AlignmentFlags.IsBidirectional | AlignmentFlags.IsInterior,
            new Vector3(0f, 0.06f, 0f),
            new Vector3(180f, 0f, 0f),
            Vector3Int.one
        );
    }
}