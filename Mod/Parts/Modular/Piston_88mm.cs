using CombustionMotors.Behaviours;
using CombustionMotors.Behaviours.CC97;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Modular;

class Piston_88mm : Part
{
    public Piston_88mm() : base("CombustionMotors/assets/combustion_motors", "88mm_piston", 199254056844878, "88mm Piston", "Props", 0.75f)
    {
        AddAttachmentPoint(
            "Conrod",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional,
            new Vector3(0f, -0.01625f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one
        );

        AddAttachmentPoint(
            "Slider",
            AttachmentTypeFlags.LinearBearing,
            AlignmentFlags.IsInterior,
            new Vector3(0f, -0.01625f, 0f),
            new Vector3(0f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddBehaviour<DisableCollisonBehaviour>();
        AddBehaviour<Piston_88mmBehaviour>();
    }
}