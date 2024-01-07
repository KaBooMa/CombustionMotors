using CombustionMotors.Behaviours;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Modular;

class Conrod_66mm : Part
{
    public Conrod_66mm() : base("CombustionMotors/assets/combustion_motors", "66mm_conrod", 433665519329955, "66mm Conrod", "Props", 0.4f)
    {
        AddAttachmentPoint(
            "BottomHole",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional | AlignmentFlags.IsFemale,
            new Vector3(0f, -0.033f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "TopHole",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional | AlignmentFlags.IsFemale,
            new Vector3(0f, 0.033f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );// 0.064722
        AddBehaviour<DisableCollisonBehaviour>();
    }
}