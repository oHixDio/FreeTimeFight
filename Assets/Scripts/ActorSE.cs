using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSE : MonoBehaviour
{
    [SerializeField] AudioClip attackSE;
    [SerializeField] AudioClip criticalSE;
    [SerializeField] AudioClip levelUpSE;
    [SerializeField] AudioClip statusUpSE;
    [SerializeField] AudioClip statusDownSE;
    [SerializeField] AudioClip systemErrorSE;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void AttackSE()
    {
        audioSource.PlayOneShot(attackSE);
    }
    public void CriticalAttackSE()
    {
        audioSource.PlayOneShot(criticalSE);
    }

    public void LevelUpSE()
    {
        audioSource.PlayOneShot(levelUpSE);
    }
    public void StatusUpSE()
    {
        audioSource.PlayOneShot(statusUpSE);
    }
    public void StatusDownSE()
    {
        audioSource.PlayOneShot(statusDownSE);
    }
    public void SystemErrorSE()
    {
        audioSource.PlayOneShot(systemErrorSE);
    }
}
