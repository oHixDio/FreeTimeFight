using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopItem : ShopItem
{
    [SerializeField] Weapon weapon;

    public override void BuyItem()
    {
        throw new System.NotImplementedException();
    }
}
