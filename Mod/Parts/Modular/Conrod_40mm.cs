using CombustionMotors.Behaviours;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Modular;

class Conrod_40mm : Part
{
    public Conrod_40mm() : base("CombustionMotors/assets/combustion_motors", "40mm_conrod", 797874332619315, "40mm Conrod", "Props", 0.3f)
    {
        AddAttachmentPoint(
            "BottomHole",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional | AlignmentFlags.IsFemale,
            new Vector3(0f, -0.02f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "TopHole",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional | AlignmentFlags.IsFemale,
            new Vector3(0f, 0.02f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );// 0.064722
        AddBehaviour<DisableCollisonBehaviour>();
    }
}