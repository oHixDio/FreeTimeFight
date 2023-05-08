using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public static BuyButton instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void SetShopItem(ShopItem shopItem)
    {
        //this.shopItem = shopItem; 
    }

    public void OnThis()
    {
        // WeaponShopèàóù
        // ArmorShopèàóù
        // todo: SE
    }
}
