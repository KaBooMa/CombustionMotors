using CombustionMotors.Behaviours;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Modular;

class Conrod_110mm : Part
{
    public Conrod_110mm() : base("CombustionMotors/assets/combustion_motors", "110mm_conrod", 705323852636055, "110mm Conrod", "Props", 0.06f)
    {
        AddAttachmentPoint(
            "BottomHole",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional | AlignmentFlags.IsFemale,
            new Vector3(0f, -0.055f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "TopHole",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional | AlignmentFlags.IsFemale,
            new Vector3(0f, 0.055f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );// 0.064722
        AddBehaviour<DisableCollisonBehaviour>();
    }
}