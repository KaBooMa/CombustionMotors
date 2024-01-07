using System.Collections.Generic;
using CombustionMotors.Behaviours;
using CombustionMotors.Behaviours.Modular;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Modular;

class Crankshaft_80mm : Part
{
    public Crankshaft_80mm() : base("CombustionMotors/assets/combustion_motors", "80mm_crankshaft", 635090444362099, "80mm Crankshaft", "Props", 2.5f, true)
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
            new Vector3(0f, -0.04f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );
        AddBehaviour<DisableCollisonBehaviour>();
        AddBehaviour<Crankshaft_80mmBehaviour>();
    }
}