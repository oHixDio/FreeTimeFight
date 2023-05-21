using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    InventorySlot[] slots;

    [SerializeField] Transform weaponSlot;

    void Awake()
    {
        slots = this.gameObject.GetComponentsInChildren<InventorySlot>();
    }
    void Start()
    {
        slots[0].IsHad = true;
    }

    public void SetWeaponSlots(int num)
    {
        if (!slots[num].IsHad) { return; }

        foreach (Transform child in weaponSlot)
        {
            Destroy(child.gameObject);
        }
        //hasItem = Instantiate(slots[num].GetItemPrefab(), weaponSlot.position, Quaternion.identity, weaponSlot);
    }

    
}

