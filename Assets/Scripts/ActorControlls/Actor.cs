using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Actor : MonoBehaviour
{
    [SerializeField] ActorStatus actorStatus;

    [SerializeField] Image faceImage;
    [SerializeField] Sprite playerSprite;
    [SerializeField] Text hpText;
    [SerializeField] Text maxHpText;
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] Text powText;
    [SerializeField] Text defText;
    [SerializeField] Text spdText;
    [SerializeField] Text lckText;
    [SerializeField] Text neText;
    [SerializeField] Text goldText;

    void Start()
    {
        ShowUI();
    }

    private void ShowUI()
    {
        actorStatus.ShowHP(hpText);
        actorStatus.ShowImage(playerSprite, faceImage);
        actorStatus.ShowName(nameText);
        actorStatus.ShowLevel(levelText);
        actorStatus.ShowPOW(powText);
        actorStatus.ShowDEF(defText);
        actorStatus.ShowSPD(spdText);
        actorStatus.ShowLCK(lckText);
        actorStatus.ShowNextEXP(neText);
        actorStatus.ShowGold(goldText);
    }


    // ActorStatusÇéÊìæ
    // MAPÇÃêîÇéÊìæÅïçXêV

    // EnemyÇÃèÍçá
    // Level Å® level + MapCurrent
    // HP Å® HP + (MapCurrent + hpUpAmount)
    // POW Å® POW + MapCurrent
    // DEF Å® DEF + MapCurrent
    // SPD Å® SPD + MapCurrent
    // LCK Å® LCK + MapCurrent
    // Dead Å® DXP + NXP

    // PlayerÇÃèÍçá
    // NXP Å® 
    // Level Å® NXP == 0
    // Levelup Å® StatusPoint + 10, NXP + (Level*100)
    // 
}
