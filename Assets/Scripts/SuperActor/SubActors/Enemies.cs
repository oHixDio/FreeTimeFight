using Cainos.CustomizablePixelCharacter;
using Cainos.PixelArtMonster_Dungeon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : Actores
{
    PixelMonster pixelMonster;

    void Awake()
    {
        pixelMonster = GetComponent<PixelMonster>();
    }
    void Update()
    {
        if (besideActor)
        {
            Attack();
        }
    }

    void Attack()
    {
        deleyTime += Time.deltaTime;

        if (attackDeleyAmount < deleyTime)
        {
            pixelMonster.Attack();
            deleyTime = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            besideActor = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            besideActor = false;
        }
    }
}
