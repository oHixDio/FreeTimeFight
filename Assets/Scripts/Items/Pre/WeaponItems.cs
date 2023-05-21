using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
public class WeaponItems : Items
{
    [SerializeField] Sprite itemIcon;
    [SerializeField] int weaponPow;

    public Sprite ItemIcon { get => itemIcon; }
    public int WeaponPow { get => weaponPow; }
}
