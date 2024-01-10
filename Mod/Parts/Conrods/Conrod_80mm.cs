using CombustionMotors.Behaviours;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Conrods;

class Conrod_80mm : Part
{
    public Conrod_80mm() : base("CombustionMotors/assets/combustion_motors", "80mm_con_rod", 18007196165631, "80mm Conrod", "Motors", 0.3f, true, true)
    {
        AddAttachmentPoint(
            "BottomHole",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional | AlignmentFlags.IsFemale,
            new Vector3(0f, 0.002f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "TopHole",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional | AlignmentFlags.IsFemale,
            new Vector3(0f, 0.087f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );
        
        AddBehaviour<DisableCollisonBehaviour>();
    }
}