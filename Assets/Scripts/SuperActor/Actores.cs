using Cainos.CustomizablePixelCharacter;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Actores : MonoBehaviour
{
    /*
    [Header("Status")]
    [SerializeField] Sprite faceIcon;
    [SerializeField] new string name = "";
    [SerializeField] int hp = 100;
    [SerializeField] int level = 1;
    [SerializeField] int pow = 5;
    [SerializeField] int spd = 5;
    [SerializeField] int mob = 5;
    [SerializeField] int lck = 5;
    [SerializeField] int skl = 20;
    [SerializeField] int sumEXP = 0;
    [SerializeField] int nextExp = 10;
    [SerializeField] int gold = 0;
    [SerializeField] int statusAddPoint = 0;
    
    int maxHp = 100;
    int maxLevel = 1250;
    int maxPow = 250;
    int maxSpd = 250;
    int maxMob = 250;
    int maxLck = 250;
    int maxskl = 1250;
    int weaponPow = 0;

    float attackDeleyTime = 0f;
    int damageAmount = 0;
    int criticalDamage = 0;

    bool isDied = false;
    bool isDestroy = false;

    ActorSE actorSE = null;

    int DamageAmount()
    {
        this.damageAmount = this.pow + this.weaponPow;
        int critical = Random.Range(0, this.lck + this.maxLck);

        if (critical > this.maxLck)
        {
            Debug.Log("クリティカル！！");
            actorSE.CriticalAttackSE();
            return criticalDamage = damageAmount * 2;
        }
        if (damageAmount > 5)
        {
            actorSE.AttackSE();
            return damageAmount;
        }
        else
        {
            actorSE.AttackSE();
            return Random.Range(0, 6);
        }
    }



    void Attack()
    {

        attackDeleyTime += Time.deltaTime;

        if (AttackDeleyAmount() < attackDeleyTime)
        {
            pixcelCharactor.Attack();
            if (enemy != null)
            {
                enemy.Damage(DamageAmount(enemy.GetEnemyStatus("def")));
            }
            attackDeleyTime = 0;
        }
    }

    public void Damage(int damageAmount)
    {
        this.hp -= damageAmount;
    }

    void Died()
    {
        pixcelCharactor.IsDead = true;
        Destroy(this.gameObject, 2f);
        isDestroy = true;
    }

    */
}
