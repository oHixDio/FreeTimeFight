using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="New Actor", fileName ="New Actor")]
public class ActorStatus : ScriptableObject
{

    // 継承の実験を行います
    // 継承が必要になったときにする

    //----------基本ステータス----------//

    //追加する場合はサブクラスの変更も修正する
    [SerializeField] protected new string name = "";
    [SerializeField] protected int hp = 100;
    [SerializeField] protected int maxHp = 100;
    [SerializeField] protected int level = 1;
    [SerializeField] protected int pow = 5;
    [SerializeField] protected int def = 5;
    [SerializeField] protected int spd = 5;
    [SerializeField] protected int lck = 5;
    [SerializeField] protected int nextExp = 10;
    [SerializeField] protected int gold = 0;

    //----------------------------------//

    

    //----------基本Status反映メソッド----------//

    //追加する場合はサブクラスの変更も修正する
    public void ShowHP(Text hpText)
    {
        hpText.text = hp.ToString();
    }
    public void ShowMaxHP(Text maxHpText)
    {
        maxHpText.text = " / " + maxHp;
    }
    public void ShowImage(Sprite faceSprite, Image image)
    {
        image.sprite = faceSprite;
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
    public void ShowNextEXP(Text neText)
    {
        neText.text = nextExp.ToString();
    }
    public void ShowGold(Text goldText)
    {
        goldText.text = gold.ToString();
    }
    
    
}
