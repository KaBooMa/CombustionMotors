using CombustionMotors.Behaviours;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Modular;

class Cylinder_96mm : Part
{
    public Cylinder_96mm() : base("CombustionMotors/assets/combustion_motors", "96mm_cylinder", 758623823686919, "96mm Cylinder", "Props", 7f, true)
    {
        AddAttachmentPoint(
            "Block",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.IsFemale,
            new Vector3(0f, -0.06f, 0f),
            new Vector3(0f, 180f, 180f),
            Vector3Int.one,
            true
        );
        
        AddAttachmentPoint(
            "Head",
            AttachmentTypeFlags.LinearBearing,
            AlignmentFlags.UNUSED,
            new Vector3(0f, 0.06f, 0f),
            new Vector3(0f, 0f, 0f),
            Vector3Int.one,
            true
        );

        for (float f = -0.04f; f < 0.04f; f += 0.001f)
        {
            AddAttachmentPoint(
                "FixedSlider"+f,
                AttachmentTypeFlags.LinearBearing,
                AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional | AlignmentFlags.IsFemale,
                new Vector3(0.0f, f, 0f),
                new Vector3(0f, 0f, 0f),
                new Vector3Int(1, 2, 1)
            );
        }

        AddBehaviour<DisableCollisonBehaviour>();
    }
}