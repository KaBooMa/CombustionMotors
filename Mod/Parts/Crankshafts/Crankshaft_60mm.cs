using CombustionMotors.Behaviours;
using CombustionMotors.Behaviours.Crankshafts;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Crankshafts;

class Crankshaft_60mm : Part
{
    public Crankshaft_60mm() : base("CombustionMotors/assets/combustion_motors", "60mm_crank", 769135780919788, "60mm Crankshaft", "Motors", 1.5f, true, true)
    {
        AddAttachmentPoint(
            "RotaryBearingCenter",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional,
            new Vector3(0f, 0f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "FixedCenterForAxles",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional | AlignmentFlags.IsFemale,
            new Vector3(0f, 0f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "FixedLeft",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.IsInterior | AlignmentFlags.IsFemale,
            new Vector3(0f, 0f, 0.05f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "FixedRight",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.IsInterior,
            new Vector3(0f, 0f, -0.05f),
            new Vector3(270f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "Conrod",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior,
            new Vector3(0f, -0.03f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );
        AddBehaviour<DisableCollisonBehaviour>();
        AddBehaviour<Crankshaft_50mmBehaviour>();
    }
}