using CombustionMotors.Behaviours.Bases;
using CombustionMotors.Behaviours.Heads;
using SmashHammer.GearBlocks.Construction;
using UnityEngine;

namespace CombustionMotors.Behaviours.Blocks;

public class EngineComponents
{
    public PartDescriptor BlockDescriptor { get { return blockDescriptor; } }
    public PartDescriptor CrankshaftDescriptor { get { return crankshaftDescriptor; } }
    public PartDescriptor ConrodDescriptor { get { return conrodDescriptor; } }
    public PartDescriptor PistonDescriptor { get { return pistonDescriptor; } }
    public PartDescriptor CylinderDescriptor { get { return cylinderDescriptor; } }
    public PartDescriptor HeadDescriptor { get { return headDescriptor; } }

    public HeadBehaviour HeadBehaviour { get { return headBehaviour; } }
    public PistonBehaviour PistonBehaviour { get { return pistonBehaviour; } }
    public BlockBehaviour BlockBehaviour { get { return blockBehaviour; } }
    public RotaryBearingAttachment CrankshaftBearing { get { return crankshaftBearing; } }
    public Rigidbody PistonRigidbody { get { return pistonRigidbody; } }
    public Rigidbody HeadRigidbody { get { return headRigidbody; } }

    public bool IsBuilt { 
        get { 
            return blockDescriptor && crankshaftDescriptor && conrodDescriptor && pistonDescriptor && cylinderDescriptor && headDescriptor; 
        } 
    }

    private readonly PartDescriptor blockDescriptor;
    private readonly PartDescriptor crankshaftDescriptor;
    private readonly PartDescriptor conrodDescriptor;
    private readonly PartDescriptor pistonDescriptor;
    private readonly PartDescriptor cylinderDescriptor;
    private readonly PartDescriptor headDescriptor;

    private readonly HeadBehaviour headBehaviour;
    private readonly PistonBehaviour pistonBehaviour;
    private readonly BlockBehaviour blockBehaviour;

    private readonly RotaryBearingAttachment crankshaftBearing;

    private readonly Rigidbody pistonRigidbody;
    private readonly Rigidbody headRigidbody;
    private readonly GameObject blockGameObject;

    public EngineComponents(GameObject blockGameObject)
    {
        this.blockGameObject = blockGameObject;

        // Grab Descriptors
        blockDescriptor = blockGameObject.GetComponent<PartDescriptor>();
        crankshaftDescriptor = FindPartOnAttachment("Crankshaft", blockDescriptor, "crank");
        conrodDescriptor = FindPartOnAttachment("Conrod", crankshaftDescriptor);
        pistonDescriptor = findPiston();
        cylinderDescriptor = FindPartOnAttachment("Cylinder", blockDescriptor);
        headDescriptor = FindPartOnAttachment("Head", cylinderDescriptor);

        // Grab Behaviours
        headBehaviour = headDescriptor.GetComponent<HeadBehaviour>();
        pistonBehaviour = pistonDescriptor.GetComponent<PistonBehaviour>();
        blockBehaviour = blockDescriptor.GetComponent<BlockBehaviour>();

        // Grab Bearing
        crankshaftBearing = blockBehaviour.GetAttachment("Crankshaft").Cast<RotaryBearingAttachment>();

        // Grab RigidBody
        pistonRigidbody = pistonDescriptor.transform.parent.GetComponent<Rigidbody>();
        headRigidbody = headDescriptor.transform.parent.GetComponent<Rigidbody>();
    }

    private PartDescriptor findPiston()
    {
        PartDescriptor conrod_1 = FindPartOnAttachment("TopHole", conrodDescriptor);
        PartDescriptor conrod_2 = FindPartOnAttachment("BottomHole", conrodDescriptor);
        if (conrod_1 && conrod_1.name.ToLower().Contains("piston"))
            return conrod_1;
        else if (conrod_2 && conrod_2.name.ToLower().Contains("piston"))
            return conrod_2;

        return null;
    }
    
    PartDescriptor FindPartOnAttachment(string attachment_name, PartDescriptor part, string part_name_contains = null)
    {
        foreach (AttachmentBase attachment in part.Attachments.associatedAttachments)
        {
            if (attachment.connectedPartPointGrid.name == "PointGrid_"+attachment_name)
            {
                if (part_name_contains == null || attachment.OwnerPart.name.ToLower().Contains(part_name_contains)) 
                    return attachment.OwnerPart;
            }
            else if (attachment.ownerPartPointGrid.name == "PointGrid_"+attachment_name)
            {
                if (part_name_contains == null || attachment.ConnectedPart.name.ToLower().Contains(part_name_contains)) 
                    return attachment.ConnectedPart;
            }
        }

        return null;
    }
}