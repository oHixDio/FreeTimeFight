using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShop : MonoBehaviour
{
    [SerializeField] GameObject shopItemStatusFrame;
    [SerializeField] Image itemIcon;
    [SerializeField] Text nameText;
    [SerializeField] Text amountText;
    [SerializeField] Text sklAmountText;
    [SerializeField] Color32 pressedButtonColor;
    [SerializeField] Color32 normalButtonColor;
    [SerializeField] Text buyButtonText;
    bool isPressed = false;
    int choiseItem;

    [SerializeField] ShopSlot[] shopSlots;

    private void Awake()
    {
        shopSlots = this.gameObject.GetComponentsInChildren<ShopSlot>();
    }
    void Update()
    {
        SetStatusFrame();
    }

    void SetStatusFrame()
    {
        shopItemStatusFrame.SetActive(isPressed);
    }

    void SetButtonColor()
    {
        buyButtonText.color = pressedButtonColor;
    }

    public void SetUI(int index)
    {
        if (shopSlots[index].InventorySlot.IsHad) { return; }

        itemIcon.sprite = shopSlots[index].Weapon.GetIcon();
        nameText.text = shopSlots[index].Weapon.GetName();
        amountText.text = shopSlots[index].Weapon.GetWeaponPow().ToString();
        sklAmountText.text = shopSlots[index].Weapon.GetSklAmount().ToString();
        isPressed = true;
        choiseItem = index;
        SetButtonColor();
    }

    public void HideUI()
    {
        isPressed = false;
        buyButtonText.color = normalButtonColor;
    }

    public void Buy()
    {
        if (!isPressed) { return; }

        shopSlots[choiseItem].BoughtItem();

        HideUI();
    }
}
