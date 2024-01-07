using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Decorations;

class Thorn_Ornament : Part
{
    public Thorn_Ornament() : base("CombustionMotors/assets/combustion_motors", "silverthorn_hood_statue", 68540139294, "Thorn Ornament", "Props", 0.5f)
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