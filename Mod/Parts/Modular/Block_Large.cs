using CombustionMotors.Behaviours;
using CombustionMotors.Behaviours.CC97;
using GearLib.Parts;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Modular;

class Block_Large : Part
{
    public Block_Large() : base("CombustionMotors/assets/combustion_motors", "large_block", 920375671938121, "Large Engine Block", "Props", 15f, true)
    {
        AddAttachmentPoint(
            "FixedBottom",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(0f, -0.0725f, 0f),
            new Vector3(0f, 180f, 180f),
            Vector3Int.one,
            true
        );
        
        AddAttachmentPoint(
            "Cylinder",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(0f, 0.0725f, 0f),
            new Vector3(0f, 0f, 0f),
            Vector3Int.one,
            true
        );

        AddAttachmentPoint(
            "Crankshaft",
            AttachmentTypeFlags.RotaryBearing,
            AlignmentFlags.IsInterior | AlignmentFlags.IsFemale | AlignmentFlags.IsBidirectional,
            new Vector3(0f, 0f, 0f),
            new Vector3(90f, 0f, 0f),
            Vector3Int.one
        );
        
        AddLinkPoint("ECU", "Electronics", Vector3.zero, can_send: false);
        AddBehaviour<DisableCollisonBehaviour>();
        AddBehaviour<CrankCase97Behaviour>();
        AddBehaviour<BlockBehaviour>();
    }
}