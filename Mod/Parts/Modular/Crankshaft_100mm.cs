using System.Collections.Generic;
using CombustionMotors.Behaviours;
using CombustionMotors.Behaviours.Modular;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Modular;

class Crankshaft_100mm : Part
{
    public Crankshaft_100mm() : base("CombustionMotors/assets/combustion_motors", "100mm_crankshaft", 20559010901721, "100mm Crankshaft", "Props", 3f)
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
            new Vector3(0f, -0.05f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );
        AddBehaviour<DisableCollisonBehaviour>();
        AddBehaviour<Crankshaft_100mmBehaviour>();
    }
}