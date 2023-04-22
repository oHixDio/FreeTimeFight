using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ActorStatus actorStatus;
    public ActorStatus ActorStatus
    {
        get { return actorStatus; }
    }

}
