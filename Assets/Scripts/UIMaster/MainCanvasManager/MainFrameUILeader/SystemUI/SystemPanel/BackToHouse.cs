using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToHouse : MonoBehaviour
{
    [SerializeField] GameObject backToHouseFrame;
    [SerializeField] GameObject pressedBackToHouseFrame;

    bool isNonePressedFrame = false;
    bool isPressedFrame = false;

    void Start()
    {
        isNonePressedFrame = true;
        isPressedFrame = false;
    }
    void Update()
    {
        ShowBackToHouseButton();
    }

    void ShowBackToHouseButton()
    {
        backToHouseFrame.SetActive(isNonePressedFrame);
        pressedBackToHouseFrame.SetActive(isPressedFrame);
    }

    public void BackToHouseButton()
    {
        isNonePressedFrame = false;
        isPressedFrame = true;
        // uiAudio.SystemButtonSE();
    }

    public void NoBackToHouse()
    {
        isNonePressedFrame = true;
        isPressedFrame = false;
        // uiAudio.SystemButtonSE();
    }

    public void YesBackToHouse()
    {
        if (UIMaster.instance.Actor.IsDied || UIMaster.instance.Actor.IsKilledBoss)
        {
            // uiAudio.SystemErrorSE();
            return;
        }

        isNonePressedFrame = true;
        isPressedFrame = false;

        UIMaster.instance.CurrentMap.CurrentMapAmountMinus();
        UIMaster.instance.Actor.ResetActorPosition();

        UIMaster.instance.MainManager.HealHouseUI.ShowHouseUI();
        UnActiveMainUI();
        HidePlayer();
        // ‰¹Šy
        //uiAudio.StopBGM();
        //uiAudio.SystemButtonSE();
    }

    

    void UnActiveMainUI()
    {
        UIMaster.instance.MainManager.HPFrameUI.gameObject.SetActive(false);
        UIMaster.instance.MainManager.MainFrameLeader.gameObject.SetActive(false);
        UIMaster.instance.MainManager.SystemButtonUI.gameObject.SetActive(false);
    }

    void HidePlayer()
    {
        UIMaster.instance.Actor.gameObject.SetActive(false);
    }
}
