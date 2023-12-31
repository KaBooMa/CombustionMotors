using CombustionMotors.Behaviours.External;
using GearLib.Behaviours;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;
using static SmashHammer.Maths.MathUtils;

namespace CombustionMotors.Parts.External;

class Piston_1x1 : Part
{
    public Piston_1x1() : base("CombustionMotors/assets/combustion_motors", "1x1_piston_head", 65399976013, "1x1 Piston Head", "Props", 3.5f, true)
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
            new Vector3(0f, 0f, 0.05f),
            new Vector3(0f, 90f, 90f),
            Vector3Int.one
        );

        AddLinkPoint("CrankshaftSensor", "Combustion", Vector3.zero, can_send: false);
        AddBehaviour<PistonBehaviour_1x1>();
    }
}