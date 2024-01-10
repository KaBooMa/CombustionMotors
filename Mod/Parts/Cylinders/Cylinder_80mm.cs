using CombustionMotors.Behaviours;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Cylinders;

class Cylinder_80mm : Part
{
    public Cylinder_80mm() : base("CombustionMotors/assets/combustion_motors", "80mm_cylinder", 974325940775247, "80mm Cylinder", "Motors", 9f, true, true)
    {
        AddAttachmentPoint(
            "Block",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.IsFemale,
            new Vector3(0f, 0f, 0f),
            new Vector3(0f, 180f, 180f),
            Vector3Int.one,
            true
        );
        
        AddAttachmentPoint(
            "Head",
            AttachmentTypeFlags.LinearBearing,
            AlignmentFlags.UNUSED,
            new Vector3(0f, 0.318f, 0f),
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
                new Vector3Int(1, 8, 1)
            );
        }

        AddBehaviour<DisableCollisonBehaviour>();
    }
}