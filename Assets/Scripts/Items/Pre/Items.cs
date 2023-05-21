using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    // Weapon 0`
    TreeBranch,
    WoodenSword,
    PirateSword,
    Axe,
    SilverSword,
    GoldenSword,
    // Armor
    GreenArmor,
    LeatherArmor,
    PirateArmor,
    VikingArmor,
    SilverArmor,
    GordenArmor,
    // Pet
    Slime,
    Spider,
    Zombie,
    Skeleton,

    max
}


public abstract class Items : ScriptableObject
{
    [SerializeField] GameObject prefab;
    [SerializeField] ItemType type;
    [SerializeField] string itemName;
    [SerializeField] bool isHad;

    public GameObject Prefab { get => prefab; }
    public ItemType Type     { get => type; }
    public string ItemName   { get => itemName; }
    public bool IsHad        { get => isHad; set => isHad = value; }
}
