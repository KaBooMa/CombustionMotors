using CombustionMotors.Behaviours;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.CC97;

class Flywheel_Inner_97 : Part
{
    public Flywheel_Inner_97() : base("CombustionMotors/assets/combustion_motors", "97cc_fly_wheel_inner", 834413015189922, "97cc Flywheel Inner Ring", "Props", 0.1f)
    {
        AddAttachmentPoint(
            "FixedOne",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional | AlignmentFlags.IsFemale,
            new Vector3(0f, 0f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "FixedTwo",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional | AlignmentFlags.IsFemale,
            new Vector3(0f, 0f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one
        );
        AddBehaviour<DisableCollisonBehaviour>();
    }
}