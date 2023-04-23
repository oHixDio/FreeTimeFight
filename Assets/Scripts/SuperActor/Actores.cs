using Cainos.CustomizablePixelCharacter;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Actores : MonoBehaviour
{
    [SerializeField] ActorStatus actorStatus;
    public ActorStatus ActorStatus
    {
        get { return actorStatus; }
    }

    protected new string name = "";
    protected int hp = 0;
    protected int maxHp = 0;
    protected int level = 0;
    protected int pow = 0;
    protected int def = 0;
    protected int spd = 0;
    protected int lck = 0;
    protected int sumEXP = 0;
    protected int nextEXP = 0;
    protected int gold = 0;
    protected Sprite faceIcon = null;

    [SerializeField] protected float attackDeleyAmount = 2f;
    protected float deleyTime = 0f;


    //----------booleançHñ[----------//
    protected bool isMove = false;
    public bool IsMove
    {
        set { isMove = value; }
    }
    protected bool isRight = false;
    public bool IsRight
    {
        set { isRight = value; }
    }
    protected bool isLeft = false;
    public bool IsLeft
    {
        set { isLeft = value; }
    }
    protected bool besideActor = false;
    public bool BesideActor
    {
        set { besideActor = value; }
    }
    //--------------------------------//







    

    public void SetStatus()
    {
        this.name = actorStatus.GetName();
        this.hp = actorStatus.GetHP();
        this.maxHp = actorStatus.GetMaxHp();
        this.level = actorStatus.GetLevel();
        this.pow = actorStatus.GetPow();
        this.def = actorStatus.GetDef();
        this.spd = actorStatus.GetSPD();
        this.lck = actorStatus.GetLck();
        this.sumEXP = actorStatus.GetSumEXP();
        this.nextEXP = actorStatus.GetNextEXP();
        this.gold = actorStatus.Getgold();
        this.faceIcon = actorStatus.GetFaceIcon();
    }

    protected void Attack(PixelCharacter pixelCharacter)
    {

        deleyTime += Time.deltaTime;

        if (attackDeleyAmount < deleyTime)
        {
            pixelCharacter.Attack();
            deleyTime = 0;
        }
    }

    protected int Damege()
    {
        return this.pow;
    }

}
