// using CombustionMotors.Behaviours;
// using CombustionMotors.Behaviours.Bases;
// using CombustionMotors.Behaviours.Modular;
// using GearLib.Parts;
// using SmashHammer.GearBlocks.Construction;
// using UnityEngine;
// using static SmashHammer.GearBlocks.Construction.PartPointGrid;

// namespace CombustionMotors.Parts.Modular;

// class Head_80mm : Part
// {
//     public Head_80mm() : base("CombustionMotors/assets/combustion_motors", "80mm_head", 921085339905657, "80mm Head", "Props", 0.8f, true)
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