using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts;

class Throttle_Lever : Part
{
    public Throttle_Lever() : base("CombustionMotors/assets/combustion_motors", "throttle_lever", 16937262745, "Throttle Lever", "Props", 5f)
    {
        AddAttachmentPoint(
            "KnuckleInner",
            AttachmentTypeFlags.KnuckleJoint,
            AlignmentFlags.IsBidirectional | AlignmentFlags.IsInterior | AlignmentFlags.IsFemale,
            new Vector3(0f, 0f, 0f),
            new Vector3(180f, 0f, 0f)
        );
    }
}