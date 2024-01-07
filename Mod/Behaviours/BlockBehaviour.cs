using GearLib.Behaviours;
using SmashHammer.GearBlocks.Construction;

namespace CombustionMotors.Behaviours;

public class BlockBehaviour : BehaviourBase
{
    public PartDescriptor block { get { return gameObject.GetComponent<PartDescriptor>(); } }
    public PartDescriptor crankshaft { get { return FindPartOnAttachment("Crankshaft", block, "crankshaft"); } }
    public PartDescriptor conrod { get { return FindPartOnAttachment("Conrod", crankshaft); } }
    public PartDescriptor piston { 
        get { 
            
            PartDescriptor conrod_1 = FindPartOnAttachment("TopHole", conrod);
            PartDescriptor conrod_2 = FindPartOnAttachment("BottomHole", conrod);
            if (conrod_1 && conrod_1.name.Contains("piston"))
            {
                return conrod_1;
            }
            else if (conrod_2 && conrod_2.name.Contains("piston"))
            {
                return conrod_2;
            }
            return null;
        }
    }

    public PartDescriptor cylinder { get { return FindPartOnAttachment("Cylinder", block); } }
    public PartDescriptor head { get { return FindPartOnAttachment("Head", cylinder); } }
    public bool is_built {
        get {
            return block && crankshaft && conrod && piston && cylinder && head;
        }
    }
    
    PartDescriptor FindPartOnAttachment(string attachment_name, PartDescriptor part, string part_name_contains = null)
    {
        foreach (AttachmentBase attachment in part.Attachments.associatedAttachments)
        {
            if (attachment.connectedPartPointGrid.name == "PointGrid_"+attachment_name)
            {
                if (part_name_contains == null || attachment.OwnerPart.name.Contains(part_name_contains)) 
                    return attachment.OwnerPart;
            }
            else if (attachment.ownerPartPointGrid.name == "PointGrid_"+attachment_name)
            {
                if (part_name_contains == null || attachment.ConnectedPart.name.Contains(part_name_contains)) 
                    return attachment.ConnectedPart;
            }
        }

        return null;
    }
}