using Cainos.CustomizablePixelCharacter;
using Cainos.PixelArtMonster_Dungeon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] Sprite faceIcon;
    [SerializeField] new string name = "";
    [SerializeField] int hp = 0;
    [SerializeField] int maxHp = 0;
    [SerializeField] int level = 1;
    [SerializeField] int pow = 2;
    [SerializeField] int def = 2;
    [SerializeField] int spd = 2;
    [SerializeField] int lck = 2;
    [SerializeField] int dropExp = 10;
    [SerializeField] int dropGold = 0;


    [Header("Infoooo")]
    [SerializeField] float attackDeleyAmount = 5f;

    PixelMonster pixelMonster;
    Actor actor;
    float deleyTime = 0f;

    bool besideActor = false;
    public bool BesideActor
    {
        set { besideActor = value; }
    }


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
        if (this.hp <= 0)
        {
            this.hp = 0;
            Died();
        }
    }

    public int GetEnemyStatus(string status)
    {
        int val = 0;
        switch (status)
        {
            case "hp":
                val = this.hp;
                break;
            case "maxHp":
                val = this.maxHp;
                break;
            case "level":
                val = this.level;
                break;
            case "pow":
                val = this.pow;
                break;
            case "def":
                val = this.def;
                break;
            case "spd":
                val = this.spd;
                break;
            case "lck":
                val = this.lck;
                break;
            case "dropExp":
                val = this.dropExp;
                break;
            case "dropGold":
                val = this.dropGold;
                break;
        }
        return val;
    }
    public Sprite GetFaceIcon()
    {
        return this.faceIcon;
    }
    public string GetName()
    {
        return this.name;
    }


    void Attack()
    {
        this.deleyTime += Time.deltaTime;

        if (this.attackDeleyAmount < this.deleyTime)
        {
            pixelMonster.Attack();
            if (actor != null)
            {
                actor.Damage(this.pow);
            }
            this.deleyTime = 0;
        }
    }

    public void Damage(int pow)
    {
        this.hp -= pow;

    }

    void Died()
    {
        pixelMonster.IsDead = true;
        Destroy(this.gameObject, 1f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            actor = collision.gameObject.GetComponent<Actor>();
            besideActor = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            actor = null;
            besideActor = false;
        }
    }


}
