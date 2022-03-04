using UnityEngine;

[CreateAssetMenu(fileName = "New Tool Item", menuName = "Inventory/Item/New Tool Item")]
public class ToolItem : Item
{
    public float DurabilityMax;
    public float StaminaUsed;
    

    private void OnValidate() {
        this.ItemType = ItemType.Tool;
    }
    
    public override void UseItem()
    {
        Debug.Log("Using " + this.ItemName);
    }
    
 
}
