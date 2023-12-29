using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts;

class Bomb_Ornament : Part
{
    public Bomb_Ornament() : base("CombustionMotors/assets/combustion_motors", "kabooba_hood_statue", 48193572300, "Bomb Ornament", "Props", 0.5f)
    {
        AddAttachmentPoint(
            "Fixed",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(0f, -0.05f, 0f),
            new Vector3(180f, 0f, 0f)
        );
    }
}