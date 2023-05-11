using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealHouse : MonoBehaviour
{
    [SerializeField] Text chatText;
    [SerializeField] Text mainText;
    [SerializeField] Text leftButtonText;
    [SerializeField] Text rightButtonText;

    int randomSentence;
    
    string[] chatSentence = 
    {
        "ここは宿屋です\n休憩しますか？",
        "体力がないと\n何もできません。",
        "ひと休み\nいかがでしょうか。"   
    };

    string[] mainSentence =
    {
        "悪い魔物を倒してきて\n親玉がいるって聞いたよ\n安心して、進んだ先でも\n休憩できるよ",
        "いつでもステータスを\n変更できるよ。増やしたり\n減らしたり、自由に変えて\n好きなように調整しよう",
        "マップを進めば進むほど\n敵はどんどん強くなるよ\nレベルアップしたらステータスを\n増やして強くなろう",
        "実績を解除したら王冠が手に入るよ\n全部コンプリートするのは\n大変だけど、達成を目指して\n頑張ってみよう"
    };

    string leftSentence = "外に出る";
    string rightSentence = "体力を\n全回復";

    void Start()
    {
        SetText();
    }
    void OnEnable()
    {
        ChangeChatText();
        ChangeMainText();
    }

    void SetText()
    {
        randomSentence = Random.Range(0, chatSentence.Length);
        chatText.text = chatSentence[randomSentence];

        randomSentence = Random.Range(0, mainSentence.Length);
        mainText.text = mainSentence[randomSentence];

        leftButtonText.text = leftSentence;
        rightButtonText.text = rightSentence;
    }

    void ChangeChatText()
    {
        randomSentence = Random.Range(0, chatSentence.Length);
        chatText.text = chatSentence[randomSentence];
    }

    public void ChangeMainText()
    {
        randomSentence = Random.Range(0, mainSentence.Length);
        mainText.text = mainSentence[randomSentence];
    }


    public void HealButton()
    {
        UIMaster.instance.Actor.FullHelth();
    }

    public void GoOutHouseButton()
    {
        ActiveMainUI();
        ShowMainUI();
        HideHealHouse();
        ShowPlayer();
    }

    void ActiveMainUI()
    {
        UIMaster.instance.MainManager.HPFrameUI.gameObject.SetActive(true);
        UIMaster.instance.MainManager.MainFrameLeader.gameObject.SetActive(true);
        UIMaster.instance.MainManager.SystemButtonUI.gameObject.SetActive(true);
    }
    void ShowMainUI()
    {
        UIMaster.instance.MainManager.MainFrameLeader.PlayerUI.ShowMainPanel();
        UIMaster.instance.GridUI.ShowMainMap();
        UIMaster.instance.MainManager.MainFrameLeader.SystemButtonUI.HideSystems();

        if (UIMaster.instance.Actor.BesideArmorArea ||
           UIMaster.instance.Actor.BesideWeaponArea ||
           UIMaster.instance.Actor.BesideHouseArea)
        {
            UIMaster.instance.MainManager.MainFrameLeader.PlayerUI.ShowEventPanel();
        }

        if (UIMaster.instance.Actor.Enemy != null)
        {
            // ShowEnemyStatus();
        }
    }

    public void ShowHouseUI()
    {
        UIMaster.instance.AreaUI.ShowHouseArea();
        UIMaster.instance.GridUI.ShowHouseMap();
        UIMaster.instance.MainManager.ShopUI.ShowHealHouse();
        ChangeChatText();
        ChangeMainText();
    }

    void HideHealHouse()
    {
        UIMaster.instance.MainManager.ShopUI.HideShopUI();
        UIMaster.instance.AreaUI.HideAnyArea();
    }

    void ShowPlayer()
    {
        UIMaster.instance.Actor.gameObject.SetActive(true);
    }
}
