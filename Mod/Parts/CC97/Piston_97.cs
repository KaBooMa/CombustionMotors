using CombustionMotors.Behaviours;
using CombustionMotors.Behaviours.CC97;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.CC97;

class Piston_97 : Part
{
    public Piston_97() : base("CombustionMotors/assets/combustion_motors", "97cc_piston", 327319398071663, "97cc Piston", "Props", 0.5f)
    {
        AddAttachmentPoint(
            "RotaryBearing",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional | AlignmentFlags.IsFemale,
            new Vector3(-0.01414f, 0f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one
        );

        AddAttachmentPoint(
            "Slider",
            AttachmentTypeFlags.LinearBearing,
            AlignmentFlags.IsInterior,
            new Vector3(0f, 0f, 0f),
            new Vector3(0f, 0f, 270f),
            Vector3Int.one,
            true
        );

        AddLinkPoint("CrankshaftSensor", "Combustion", Vector3.zero, can_send: false);
        AddBehaviour<DisableCollisonBehaviour>();
        AddBehaviour<PistonBehaviour_97>();
    }
}