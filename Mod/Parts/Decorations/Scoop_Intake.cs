using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Decorations;

class Scoop_Intake : Part
{
    public Scoop_Intake() : base("CombustionMotors/assets/combustion_motors", "scoop_intake", 7154292355, "Scoop Intake", "Props", 15f)
    {
        AddAttachmentPoint(
            "Fixed",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(0f, -0.2f, 0f),
            new Vector3(180f, 0f, 0f),
            Vector3Int.one,
            true
        );
    }
}