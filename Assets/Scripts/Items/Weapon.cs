using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create Weapon")]
public class Weapon : Item
{
    [SerializeField] Sprite iconImage;
    [SerializeField] int weaponPow;

    public int GetWeaponPow()
    {
        return weaponPow;
    }
}
