using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="New Actor", fileName ="New Actor")]
public class ActorStatus : ScriptableObject
{

    // �p���̎������s���܂�
    // �p�����K�v�ɂȂ����Ƃ��ɂ���

    //----------��{�X�e�[�^�X----------//

    //�ǉ�����ꍇ�̓T�u�N���X�̕ύX���C������
    [SerializeField] protected new string name = "";
    [SerializeField] protected int hp = 100;
    [SerializeField] protected int maxHp = 100;
    [SerializeField] protected int level = 1;
    [SerializeField] protected int pow = 5;
    [SerializeField] protected int def = 5;
    [SerializeField] protected int spd = 5;
    [SerializeField] protected int lck = 5;
    [SerializeField] protected int sumEXP = 0;
    [SerializeField] protected int nextExp = 10;
    [SerializeField] protected int gold = 0;
    [SerializeField] protected Sprite faceIcon;

    //----------------------------------//

    

    //----------��{Status���f���\�b�h----------//

    //�ǉ�����ꍇ�̓T�u�N���X�̕ύX���C������
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
