using CombustionMotors.Behaviours;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.CC97;

class Flywheel_Outer_97 : Part
{
    public Flywheel_Outer_97() : base("CombustionMotors/assets/combustion_motors", "97cc_fly_wheel_outer", 142613346413259, "97cc Flywheel Outer Ring", "Props", 0.2f)
    {
        AddAttachmentPoint(
            "Fixed",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.IsInterior,
            new Vector3(0f, 0f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );
        AddBehaviour<DisableCollisonBehaviour>();
    }
}