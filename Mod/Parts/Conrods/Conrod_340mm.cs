using CombustionMotors.Behaviours;
using GearLib.API;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Conrods;

class Conrod_340mm : Part
{
    public Conrod_340mm() : base("CombustionMotors/assets/combustion_motors", "340mm_con_rod", 823440702986056, "340mm Conrod", "Motors", 0.3f, true, true)
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
            new Vector3(0f, 0.347f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );
        
        AddBehaviour<DisableCollisonBehaviour>();
    }
}