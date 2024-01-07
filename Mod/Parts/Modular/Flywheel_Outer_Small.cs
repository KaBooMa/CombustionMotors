using CombustionMotors.Behaviours;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Modular;

class Flywheel_Outer_Small : Part
{
    public Flywheel_Outer_Small() : base("CombustionMotors/assets/combustion_motors", "small_fly_wheel_outer", 108984571301545, "Small Outer Flywheel", "Props", 7f)
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