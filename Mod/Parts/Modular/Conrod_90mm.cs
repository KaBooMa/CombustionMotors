using CombustionMotors.Behaviours;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Modular;

class Conrod_90mm : Part
{
    public Conrod_90mm() : base("CombustionMotors/assets/combustion_motors", "90mm_conrod", 148324898296651, "90mm Conrod", "Props", 0.5f)
    {
        AddAttachmentPoint(
            "BottomHole",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional | AlignmentFlags.IsFemale,
            new Vector3(0f, -0.045f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "TopHole",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional | AlignmentFlags.IsFemale,
            new Vector3(0f, 0.045f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );// 0.064722
        AddBehaviour<DisableCollisonBehaviour>();
    }
}