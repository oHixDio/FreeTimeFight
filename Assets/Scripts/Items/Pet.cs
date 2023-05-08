using Cainos.PixelArtMonster_Dungeon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create Pet")]
public class Pet : Item
{
    [SerializeField] int petPow;
    [SerializeField] int petSpd;
    [SerializeField] int petLck;

    PixelMonster pixelMonster;

    void Awake()
    {
        pixelMonster = itemPrefab.gameObject.GetComponent<PixelMonster>();
    }

    public void Attack()
    {
        pixelMonster.Attack();
    }

    public void Damage()
    {
        
    }
}
