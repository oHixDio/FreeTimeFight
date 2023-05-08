using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create Armor")]
public class Armor : Item
{
    [SerializeField] Sprite hat;
    [SerializeField] Sprite cloth;
    [SerializeField] Sprite pants;
    [SerializeField] Sprite shoes;
    [SerializeField] Sprite socks;
    [SerializeField] int armorDef;
}
