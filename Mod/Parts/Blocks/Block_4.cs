using CombustionMotors.Behaviours;
using CombustionMotors.Behaviours.Blocks;
using GearLib.API;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;
using static SmashHammer.GearBlocks.Construction.PartPointGrid;

namespace CombustionMotors.Parts.Blocks;

class Block_4 : Part
{
    public Block_4() : base("CombustionMotors/assets/combustion_motors", "crank_4", 941716401746215, "Large AF Engine Block", "Motors", 60f, true, true)
    {
        AddAttachmentPoint(
            "FixedBottom",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(0f, -0.2f, 0f),
            new Vector3(0f, 180f, 180f),
            Vector3Int.one,
            true
        );
        
        AddAttachmentPoint(
            "Cylinder",
            AttachmentTypeFlags.Fixed,
            AlignmentFlags.UNUSED,
            new Vector3(0f, 0.2f, 0f),
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
        AddBehaviour<BlockBehaviour>();
    }
}