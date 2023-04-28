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
    [SerializeField] int maxSpd = 500;
    [SerializeField] int lck = 2;
    [SerializeField] int maxLck = 500;
    [SerializeField] int dropExp = 10;
    [SerializeField] int dropGold = 0;
    

    [Header("Infoooo")]
    [SerializeField] float originDeleyAmount = 5f;
    [SerializeField] int damageAdjust = 0;

    PixelMonster pixelMonster;
    Actor actor;
    float deleyTime = 0f;
    int damageAmount = 0;
    int criticalDamage = 0;

    bool besideActor = false;
    public bool BesideActor
    {
        set { besideActor = value; }
    }
    bool isDied = false;
    bool isDestroy = false;


    void Awake()
    {
        pixelMonster = GetComponent<PixelMonster>();
    }
    void Update()
    {
        if (isDestroy) { return; }

        if (isDied) { Died(); }

        if (besideActor) { Attack(); }

        if (this.hp <= 0)
        {
            this.hp = 0;
            isDied = true;
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
    
    public bool GetEnemyDied()
    {
        return isDied;
    }
    public int DamageAmount(int otherDef)
    {
        this.damageAmount = (this.pow / 2 - otherDef / 4) * this.damageAdjust;
        int critical = Random.Range(0, this.lck + maxLck);

        if (critical > maxLck)
        {
            Debug.Log("�N���e�B�J���I�I");
            return criticalDamage = damageAmount * 2;

        }
        if (damageAmount > 5)
        {
            return damageAmount;
        }
        else
        {
            return Random.Range(0, 6);
        }
        
    }

    bool isStatusUp = false;
    public void CurrentStatus(int mapAmount)
    {
        if (mapAmount <= 1) { return; }
        
        if (isStatusUp == false)
        {
            mapAmount--;
            this.level += mapAmount;
            this.hp += mapAmount * 12;
            this.maxHp += mapAmount * 12;
            this.pow += mapAmount;
            this.def += mapAmount;
            this.spd += mapAmount;
            this.lck += mapAmount;
            this.dropExp += mapAmount;
            isStatusUp = true;
        }
    }
    



    void Attack()
    {
        this.deleyTime += Time.deltaTime;

        if (originDeleyAmount < this.deleyTime)
        {
            pixelMonster.Attack();
            if (actor != null)
            {
                actor.Damage(DamageAmount(actor.GetDefAmount()));
            }
            this.deleyTime = 0;
        }
    }

    public void Damage(int damageAmount)
    {
        Debug.Log(damageAmount);
        this.hp -= damageAmount;
    }

    void Died()
    {
        pixelMonster.IsDead = true;
        Destroy(this.gameObject, 1f);
        actor.CurrentPlayerEXP(dropExp);
        isDestroy = true;
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
