using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actor", fileName ="new Actor")]
public class ActorStatus : ScriptableObject
{

    // åpè≥ÇÃé¿å±ÇçsÇ¢Ç‹Ç∑

    //name
    [SerializeField] new string name = "";
    //hp
    [SerializeField] int hp = 100;
    //maxHP
    [SerializeField] int maxHp = 100;
    //level
    [SerializeField] int level = 1;
    //pow
    [SerializeField] int pow = 5;
    //def
    [SerializeField] int def = 5;
    //speed
    [SerializeField] int speed = 5;
    //mobility
    [SerializeField] int mobility = 5;
    //maxMobility
    [SerializeField] int maxMobility = 5;
    //luck
    [SerializeField] int luck = 5;
    //exp
    [SerializeField] int exp = 0;
    //nextLevelEXP
    [SerializeField] int nextEXP = 1;


}
