using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] GameObject weaponShop;
    [SerializeField] GameObject armorShop;
    [SerializeField] GameObject healHouse;

    public void HideShopUI()
    {
        weaponShop.SetActive(false);
        armorShop.SetActive(false);
        healHouse.SetActive(false);
    }

    public void ShowHealHouse()
    {
        HideShopUI();

        healHouse.SetActive(true);
    }

    public void ShowWeaponShop()
    {
        HideShopUI();

        weaponShop.SetActive(true);
    }

    public void ShowArmorShop()
    {
        HideShopUI();

        armorShop.SetActive(true);
    }
}
