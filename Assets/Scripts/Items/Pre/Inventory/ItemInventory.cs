using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

public class ItemInventory : MonoBehaviour
{
    ItemData itemData;
    ItemInventorySlot[] slots;
    [SerializeField] Items[] inventoryItems;
    public Items[] InventoryItems { get => inventoryItems; }

    private void Awake()
    {
        itemData = new ItemData();
        slots = this.gameObject.GetComponentsInChildren<ItemInventorySlot>();
        SetHadItems();
    }
    private void Update()
    {
        SetSlotsText();
    }

    void SetHadItems()
    {
        int index = 0;
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            index = (int)inventoryItems[i].Type;

            inventoryItems[i].IsHad = itemData.HadItems[index];
        }
    }

    void SetSlotsText()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            for (int j = 0; j < inventoryItems.Length; j++)
            {
                if(slots[i].Items.Type == inventoryItems[j].Type)
                {
                    slots[i].SetIsHadItems(inventoryItems[j].IsHad);
                }
                
            }
        }
        
    }

    
}

