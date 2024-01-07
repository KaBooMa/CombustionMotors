using GearLib.Behaviours;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;

namespace CombustionMotors.Behaviours;

class DisableCollisonBehaviour : BehaviourBase
{
    bool is_frozen = false;

    void FixedUpdate()
    {
        if (GetComponent<PartDescriptor>().ParentConstruction.IsFrozen)
        {
            is_frozen = true;
            return;
        }
        else if (is_frozen)
        {
            // Disable collision with all parts upon unfreezing
            foreach (PartDescriptor other_desc in descriptor.ParentConstruction.Parts)
            {
                Collider collider = descriptor.GetComponentInChildren<Collider>();
                foreach (Collider other_collider in other_desc.GetComponentsInChildren<Collider>())
                {
                    Physics.IgnoreCollision(other_collider, collider, true);
                }
            }

            is_frozen = false;
        }
    }
}