using SmashHammer.GearBlocks.Construction;
using UnityEngine;

namespace CombustionMotors.Utility;

public class BlockUtility {
    private readonly PartDescriptor block;
    private readonly PartDescriptor crankshaft;
    private readonly PartDescriptor conrod;
    private readonly PartDescriptor piston;
    private readonly PartDescriptor cylinder;
    private readonly PartDescriptor head;
        
    public BlockUtility(GameObject blockGameObject)
    {        
        block = blockGameObject.GetComponent<PartDescriptor>().FindPartOnAttachment("Block", "block");
        crankshaft = block.FindPartOnAttachment("Crankshaft","crankshaft");

        PartDescriptor findPiston() {
            PartDescriptor conrod_1 = conrod.FindPartOnAttachment("TopHole");
            PartDescriptor conrod_2 = conrod.FindPartOnAttachment("BottomHole");
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
        conrod = crankshaft.FindPartOnAttachment("Conrod");
        piston = findPiston();
        cylinder = block.FindPartOnAttachment("Cylinder");
        head = cylinder.FindPartOnAttachment("Head");
    }

    public PartDescriptor Block { get { return block; } }
    public PartDescriptor Crankshaft { get { return crankshaft; } }
    public PartDescriptor Conrod { get { return conrod; } }
    public PartDescriptor Piston { 
        get {  return piston;
        }
    }

    public PartDescriptor Cylinder { get { return cylinder; } }
    public PartDescriptor Head { get { return head; } }
    public bool IsBuilt {
        get {
            return block && crankshaft && conrod && piston && cylinder && head;
        }
    }
    
    
}