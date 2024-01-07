using CombustionMotors.Behaviours;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.CC97;

class Conrod_97 : Part
{
    public Conrod_97() : base("CombustionMotors/assets/combustion_motors", "97cc_con_rod_needs_update_later", 563615686537867, "97cc Conrod", "Props", 0.17f, true)
    {
        AddAttachmentPoint(
            "RotaryBearingOne",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior,
            new Vector3(-0.0286f, 0f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "RotaryBearingTwo",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior,
            new Vector3(0.0286f, 0f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one,
            true
        );// 0.064722
        AddBehaviour<DisableCollisonBehaviour>();
    }
}