using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventorySlot : MonoBehaviour
{
    [SerializeField] Items items;
    Text slotItemNameText;
    string dontHaveText = "- - -";

    public Items Items { get => items; }

    private void Awake()
    {
        slotItemNameText = GetComponentInChildren<Text>();
    }
    private void Start()
    {
        SetDefaultText();
        
    }
    private void Update()
    {
        SetItemName();
    }

    void SetDefaultText()
    {
        slotItemNameText.text = dontHaveText;
    }

    public void SetItemName()
    {
        if (!items.IsHad) { return; }
        slotItemNameText.text = items.ItemName;
    }

    public void SetIsHadItems(bool isHad)
    {
        items.IsHad = isHad;
    }

    
}
