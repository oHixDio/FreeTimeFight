using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="New Actor", fileName ="New Actor")]
public class ActorStatus : ScriptableObject
{


    //----------基本ステータス----------//

    [SerializeField] new string name = "";
    [SerializeField] int hp = 100;
    [SerializeField] int maxHp = 100;
    [SerializeField] int level = 1;
    [SerializeField] int pow = 5;
    [SerializeField] int def = 5;
    [SerializeField] int spd = 5;
    [SerializeField] int lck = 5;
    [SerializeField] int sumEXP = 0;
    [SerializeField] int nextExp = 10;
    [SerializeField] int gold = 0;
    [SerializeField] Sprite faceIcon;

    //----------------------------------//

    //----------基本ステータス受け渡しメソッド----------//

    public string GetName()
    {
        return name;
    }
    public int GetHP()
    {
        return hp;
    }
    public int GetMaxHp()
    {
        return maxHp;
    }
    public int GetLevel()
    {
        return level;
    }
    public int GetPow()
    {
        return pow;
    }
    public int GetDef()
    {
        return def;
    }
    public int GetSPD()
    {
        return spd;
    }
    public int GetLck()
    {
        return lck;
    }
    public int GetSumEXP()
    {
        return sumEXP;
    }
    public int GetNextEXP()
    {
        return nextExp;
    } 
    public int Getgold()
    {
        return gold;
    }
    public Sprite GetFaceIcon()
    {
        return faceIcon;
    }





    //----------基本Status反映メソッド----------//

    //追加する場合はサブクラスの変更も修正する
    public void ShowHP(Text hpText)
    {
        hpText.text = hp.ToString();
    }
    public void ShowMaxHP(Text maxHpText)
    {
        maxHpText.text = maxHp.ToString();
    }
    public void ShowImage(Image image)
    {
        image.sprite = faceIcon;
    }
    public void ShowName(Text nameText)
    {
        nameText.text = name;
    }
    public void ShowLevel(Text levelText)
    {
        levelText.text = level.ToString();
    }
    public void ShowPOW(Text powText)
    {
        powText.text = pow.ToString();
    }
    public void ShowDEF(Text defText)
    {
        defText.text = def.ToString();
    }
    public void ShowSPD(Text spdText)
    {
        spdText.text = spd.ToString();
    }
    public void ShowLCK(Text lckText)
    {
        lckText.text = lck.ToString();
    }
    public void ShowSumEXP(Text sumText)
    {
        sumText.text = sumEXP.ToString();
    }
    public void ShowNextEXP(Text neText)
    {
        neText.text = nextExp.ToString();
    }
    public void ShowGold(Text goldText)
    {
        goldText.text = gold.ToString();
    }


    
}
