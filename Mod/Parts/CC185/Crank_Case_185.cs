using CombustionMotors.Behaviours;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.CC97;

class Crank_Case_185 : Part
{
    public Crank_Case_185() : base("CombustionMotors/assets/combustion_motors", "185cc_crank_case", 494429698958452, "185cc Crank Case", "Props", 20f, true)
    {
        AddAttachmentPoint(
            "FixedSlider",
            AttachmentTypeFlags.LinearBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsFemale,
            new Vector3(0.092f, 0f, 0f),
            new Vector3(0f, 0f, 90f),
            Vector3Int.one
        );
        SetAttachmentSize("FixedSlider", new Vector3Int(1, 3, 1));

        AddAttachmentPoint(
            "FixedBottom",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(-0.05f, 0f, 0f),
            new Vector3(0f, 0f, 90f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "Crankshaft",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsBidirectional | AlignmentFlags.IsFemale,
            new Vector3(0f, 0f, 0.05f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one
        );
        
        AddLinkPoint("ECU", "Electronics", new Vector3(0, -0.1f, 0), can_send: false);
        AddLinkPoint("Pistons", "Combustion", new Vector3(0, 0.1f, 0), can_receive: false);
        AddBehaviour<DisableCollisonBehaviour>();
        // AddBehaviour<CrankCase97Behaviour>();
    }
}