using CombustionMotors.Behaviours.External;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;
using static SmashHammer.Maths.MathUtils;

namespace CombustionMotors.Parts.External;

class Piston_2x2 : Part
{
    public Piston_2x2() : base("CombustionMotors/assets/combustion_motors", "2x2_piston_head", 17834789626, "2x2 Piston Head", "Props", 7f)
    {
        SliderRailBehaviour slider = game_object.AddComponent<SliderRailBehaviour>();
        slider.slidingAxis = Axis.Y_Axis;
        AddAttachmentPoint(
            "Knuckle",
            AttachmentTypeFlags.KnuckleJoint,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional,
            new Vector3(0f, 0f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );
        AddAttachmentPoint(
            "Slider",
            AttachmentTypeFlags.LinearBearing,
            AlignmentFlags.UNUSED,
            new Vector3(0f, 0f, 0.1f),
            new Vector3(0f, 90f, 90f),
            Vector3Int.one
        );

        AddLinkPoint("CrankshaftSensor", "Combustion", Vector3.zero, can_send: false);
        AddBehaviour<PistonBehaviour_2x2>();
    }
}