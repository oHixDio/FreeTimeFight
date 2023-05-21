using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "Items/Armor")]
public class ArmorItems : Items
{
    [SerializeField] Sprite itemIconHat;
    [SerializeField] Sprite itemIconCloth;
    [SerializeField] Sprite itemIconPants;
    [SerializeField] Sprite itemIconShoes;
    [SerializeField] bool clipHear;
    [SerializeField] int armorDef;

    public Sprite ItemIconHat { get => itemIconHat; }
    public Sprite ItemIconCloth { get => itemIconCloth; }
    public Sprite ItemIconPants { get => itemIconPants; }
    public Sprite ItemIconShoes { get => itemIconShoes; }
    public bool ClipHear { get => clipHear; }
    public int Armordef { get => armorDef; }
}
