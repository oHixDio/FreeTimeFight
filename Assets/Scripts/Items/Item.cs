using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    TreeBranch,
    WoodenSword,
    PirateSword,
    Axe,
    SilverSword,
    goldenSword,

    GreenArmor,
    LeatherArmor,
    PirateArmor,
    VikingArmor,
    SilverArmor,
    GoldenArmor,

    Slime,
    Spider,
    Zombie,
    Skeleton,


}


public abstract class Item : ScriptableObject
{
    [SerializeField] protected GameObject itemPrefab;
    [SerializeField] protected ItemType type;
    [SerializeField] protected string itemName;
    [SerializeField] protected bool isHad;

    public void HaveItem()
    {
        isHad = true;
    }

    public void UnHaveItem()
    {
        isHad = false;
    }

    public bool GetIsHad()
    {
        return isHad;
    }

    public string GetItemName()
    {
        return itemName;
    }

}
