using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pet", menuName = "Items/Pet")]
public class PetItems : Items
{
    [SerializeField] Sprite itemIcon;
    [SerializeField] int petPow;
    [SerializeField] int petSpd;
    [SerializeField] int petLck;
}
