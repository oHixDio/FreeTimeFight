using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// TODO:
// MapText�ύX
// FieldText�ύX
// PopupInfo�\��
public class InfoPanelUI : MonoBehaviour
{
    [SerializeField] Text mapAmountText;
    [SerializeField] Text currentFieldAmountText;
    [SerializeField] GameObject popupInfoFrame;
    [SerializeField] Text popupInfoText;

    string levelupLine = "<color=#ffd400>Level UP!!</color>";
    string dropExpLine = "EXP";
    string goldLine = "G";

    void Update()
    {
        ChangeMapAmountText();
        ChangeCurrentFiledAmountText();
    }

    void ChangeMapAmountText()
    {
        mapAmountText.text = "MAP:" + UIMaster.instance.CurrentMap.GetMapAmount().ToString();
    }
    void ChangeCurrentFiledAmountText()
    {
        currentFieldAmountText.text = "F:" + UIMaster.instance.CurrentMap.GetCurrentFieldAmount().ToString();
    }

    // PopupUI�֌W
    // type => 0:null 1:null�ł͂Ȃ�
    public string SetLevelLine(int num)
    {
        if (num == 1)
        {
            return levelupLine;
        }
        else
        {
            return string.Empty;
        }
    }
    public string SetDropExpLine(int num, int otherDropExp)
    {
        if (num == 1)
        {
            return otherDropExp + dropExpLine;
        }
        else
        {
            return string.Empty;
        }
    }
    public string SetGoldLine(int num, int otherDropGold)
    {
        if (num == 1)
        {
            return otherDropGold + goldLine;
        }
        else
        {
            return string.Empty;
        }
    }
    public string SetEnemyKillLine(string l, string e, string g)
    {
        return l + " " + e + " " + g;
    }


    public void ShowEnemyKillPopup(int l, int e, int exp, int g, int gold)
    {
        popupInfoFrame.SetActive(true);
        popupInfoText.text = SetEnemyKillLine(SetLevelLine(l), SetDropExpLine(e, exp), SetGoldLine(g, gold));
        Invoke("HidePopupInfoFrame", 3.5f);
    }
    void HidePopupInfoFrame()
    {
        popupInfoFrame.SetActive(false);
    }

}