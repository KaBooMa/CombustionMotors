using CombustionMotors.Behaviours;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Conrods;

class Conrod_360mm : Part
{
    public Conrod_360mm() : base("CombustionMotors/assets/combustion_motors", "360mm_con_rod", 72184425190864, "360mm Conrod", "Motors", 0.3f, true, true)
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
            new Vector3(0f, 0.367f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );
        
        AddBehaviour<DisableCollisonBehaviour>();
    }
}