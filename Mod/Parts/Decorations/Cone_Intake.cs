using GearLib.API;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Decorations;

class Cone_Intake : Part
{
    public Cone_Intake() : base("CombustionMotors/assets/combustion_motors", "cone_intake", 19850179660, "Air Filter", "Props", 0.1f, true)
    {
        AddAttachmentPoint(
            "Fixed",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(0f, -0.1f, 0f),
            new Vector3(180f, 0f, 0f),
            Vector3Int.one,
            true
        );
    }
}