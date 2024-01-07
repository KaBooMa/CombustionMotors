// using CombustionMotors.Behaviours;
// using CombustionMotors.Behaviours.Bases;
// using CombustionMotors.Behaviours.Modular;
// using GearLib.Parts;
// using SmashHammer.GearBlocks.Construction;
// using UnityEngine;
// using static SmashHammer.GearBlocks.Construction.PartPointGrid;

// namespace CombustionMotors.Parts.Modular;

// class Head_88mm : Part
// {
//     public Head_88mm() : base("CombustionMotors/assets/combustion_motors", "88mm_head", 285928039610619, "88mm Head", "Props", 0.8f)
//     {
//         AddAttachmentPoint(
//             "Cylinder",
//             AttachmentTypeFlags.Fixed,
//             AlignmentFlags.IsFemale,
//             new Vector3(0f, -0.04f, 0f),
//             new Vector3(0f, 180f, 180f),
//             Vector3Int.one,
//             true
//         );

//         AddBehaviour<DisableCollisonBehaviour>();
//         AddBehaviour<HeadBehaviour>();
//     }
// }