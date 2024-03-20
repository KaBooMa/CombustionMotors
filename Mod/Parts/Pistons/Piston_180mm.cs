using CombustionMotors.Behaviours;
using CombustionMotors.Behaviours.Pistons;
using GearLib.API;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Pistons;

class Piston_180mm : Part
{
    public Piston_180mm() : base("CombustionMotors/assets/combustion_motors", "180mm_piston", 483632560950397, "180mm Piston", "Motors", 0.6f, true, true)
    {
        AddAttachmentPoint(
            "Conrod",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional,
            new Vector3(0f, 0f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one
        );

        AddAttachmentPoint(
            "Slider",
            AttachmentTypeFlags.LinearBearing,
            AlignmentFlags.IsInterior,
            new Vector3(0f, 0f, 0f),
            new Vector3(0f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddBehaviour<DisableCollisonBehaviour>();
        AddBehaviour<Piston_180mmBehaviour>();
    }
}