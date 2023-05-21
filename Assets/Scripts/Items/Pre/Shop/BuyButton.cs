using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    ShopItemSlot slot;
    [SerializeField] ItemInventory inventory;

    public void SetSlots(ShopItemSlot slot)
    {
        this.slot = slot;
        Debug.Log(this.slot);
    }

    public void Buy()
    {
        this.slot.Items.IsHad = true;
        for (int i = 0; i < inventory.InventoryItems.Length; i++)
        {
            if(this.slot.Items.Type == inventory.InventoryItems[i].Type)
            {
                inventory.InventoryItems[i].IsHad = true;
                Debug.Log(inventory.InventoryItems[i]);
            }
        }

    }
}
