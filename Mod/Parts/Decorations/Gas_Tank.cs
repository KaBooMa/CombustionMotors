using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Decorations;

class Gas_Tank : Part
{
    public Gas_Tank() : base("CombustionMotors/assets/combustion_motors", "gas_tank", 85981766481, "Gas Tank", "Props", 25f, true)
    {
        AddAttachmentPoint(
            "BackRight",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(0.1f, 0.03f, -0.1f),
            new Vector3(270f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "BackLeft",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(-0.1f, 0.03f, -0.1f),
            new Vector3(270f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "BottomRight",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(0.1f, -0.12f, 0.05f),
            new Vector3(180f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "BottomLeft",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(-0.1f, -0.12f, 0.05f),
            new Vector3(180f, 0f, 0f),
            Vector3Int.one,
            true
        );
    }
}