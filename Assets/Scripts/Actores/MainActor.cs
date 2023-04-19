using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Main Actor", fileName = "new Actor")]
public class MainActor : ActorStatus
{
    [SerializeField] int mobility = 5;
    [SerializeField] int maxMobility = 5;
    [SerializeField] int haveEXP = 0;
    [SerializeField] int nextEXP = 1;
    [SerializeField] int distributeStatusPoint = 0;
}
    

    
