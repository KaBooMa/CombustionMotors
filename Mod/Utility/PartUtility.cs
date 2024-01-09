using SmashHammer.GearBlocks.Construction;
using UnityEngine;

namespace CombustionMotors.Utility;

public static class PartUtility
{
    public static PartDescriptor FindPartOnAttachment(this PartDescriptor part, string attachment_name, string part_name_contains = null)
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