using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Text itemText;

    void SetItemText()
    {
        itemText.text = item.name;
    }
   
}
