using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemSlot : MonoBehaviour
{
    [SerializeField] Items items;
    Text shopSlotText;
    BuyButton buyBtn;
    string boughtText = "- - -";

    public Items Items { get => items; }

    void Awake()
    {
        buyBtn = GetComponentInParent<BuyButton>();
        shopSlotText = GetComponentInChildren<Text>();
    }
    void Start()
    {
        SetDefaultText();
    }
    private void Update()
    {
        SetBoughtText();
    }

    void SetDefaultText()
    {
        shopSlotText.text =  items.ItemName;
    }

    void SetBoughtText()
    {
        if (!items.IsHad) { return; }
        shopSlotText.text = boughtText;
    }

    public void SetBuyButton()
    {
        buyBtn.SetSlots(this);
    }
}
