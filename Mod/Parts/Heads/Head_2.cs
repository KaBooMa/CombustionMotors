using CombustionMotors.Behaviours;
using CombustionMotors.Behaviours.Heads;
using GearLib.API;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Heads;

class Head_2 : Part
{
    public Head_2() : base("CombustionMotors/assets/combustion_motors", "cylinder_head_2", 206675345192958, "Medium Cylinder Head", "Motors", 0.8f, true, true)
    {
        AddAttachmentPoint(
            "Cylinder",
            AttachmentTypeFlags.LinearBearing,
            AlignmentFlags.IsFemale,
            new Vector3(0f, -0.04f, 0f),
            new Vector3(0f, 180f, 180f),
            Vector3Int.one,
            true
        );

        AddBehaviour<DisableCollisonBehaviour>();
        AddBehaviour<HeadBehaviour>();
    }
}