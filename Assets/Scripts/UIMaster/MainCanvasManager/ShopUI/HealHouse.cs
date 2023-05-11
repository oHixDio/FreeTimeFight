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
        "�����͏h���ł�\n�x�e���܂����H",
        "�̗͂��Ȃ���\n�����ł��܂���B",
        "�ЂƋx��\n�������ł��傤���B"   
    };

    string[] mainSentence =
    {
        "����������|���Ă���\n�e�ʂ�������ĕ�������\n���S���āA�i�񂾐�ł�\n�x�e�ł����",
        "���ł��X�e�[�^�X��\n�ύX�ł����B���₵����\n���炵����A���R�ɕς���\n�D���Ȃ悤�ɒ������悤",
        "�}�b�v��i�߂ΐi�ނق�\n�G�͂ǂ�ǂ񋭂��Ȃ��\n���x���A�b�v������X�e�[�^�X��\n���₵�ċ����Ȃ낤",
        "���т����������牤������ɓ����\n�S���R���v���[�g����̂�\n��ς����ǁA�B����ڎw����\n�撣���Ă݂悤"
    };

    string leftSentence = "�O�ɏo��";
    string rightSentence = "�̗͂�\n�S��";

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
