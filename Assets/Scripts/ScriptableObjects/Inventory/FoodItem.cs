using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Food Item", menuName = "Inventory/Item/New Food Item")]
public class FoodItem : Item
{
    public float HealthRecoveryAmount;
    public float StaminaRecoveryAmount;

    private void OnValidate() {
        this.ItemType = ItemType.Food;
    }
    
    public override void UseItem()
    {
        base.UseItem();
        Debug.Log("FOOD!");
    }
    
 
}


