using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudio : MonoBehaviour
{
    [SerializeField] GameObject audioBGM;
    [SerializeField] AudioClip systembuttonSE;
    [SerializeField] AudioClip systemErrorSE;
    [SerializeField] AudioClip hpHealSE;


    AudioSource seAudioSource;
    AudioSource bgmAudioSource;

    void Awake()
    {
        seAudioSource = GetComponent<AudioSource>();
        bgmAudioSource = audioBGM.GetComponent<AudioSource>();
    }

    public void SystemButtonSE()
    {
        seAudioSource.PlayOneShot(systembuttonSE);
    }

    public void SystemErrorSE()
    {
        seAudioSource.PlayOneShot(systemErrorSE);
    }

    public void FullHealthSE()
    {
        seAudioSource.PlayOneShot(hpHealSE);
    }

    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }
    public void PlayBGM()
    {
        bgmAudioSource.Play();
    }
}
