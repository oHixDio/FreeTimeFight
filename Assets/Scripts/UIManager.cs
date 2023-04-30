using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("BGUICanvas")]
    [SerializeField] GameObject bgUICanvas;
    [SerializeField] GameObject forestBG;
    [SerializeField] GameObject desertBG;
    [SerializeField] GameObject graveyardBG;
    [SerializeField] GameObject snowBG;
    List<GameObject> bgList = new List<GameObject>();


    [Header("SystemUICanvas")]
    [SerializeField] GameObject systemUICanvas;
    [SerializeField] Text mapAmountText;
    [SerializeField] GameObject popupInfoFrame;
    [SerializeField] Text popupInfoText;
    [SerializeField] GameObject systemMain;
    [SerializeField] GameObject systemFooter;
    [SerializeField] GameObject systemPanel;
    [SerializeField] GameObject levelupPanel;
    [SerializeField] GameObject achievementPanel;
    [SerializeField] Text systemPowText;
    [SerializeField] Text systemDefText;
    [SerializeField] Text systemSpdText;
    [SerializeField] Text systemLckText;
    [SerializeField] Text systemSklText;
    [SerializeField] Text systemcurrentHpText;
    [SerializeField] Text systemStatusAddPointText;

    string levelupLine = "<color=#ffd400>Level UP!!</color>";
    string dropExpLine = "EXP";
    string goldLine = "G";

    bool showSystemPanel = false;
    bool showLevelupPanel = false;
    bool showAchievementPanel = false;


    [Header("PlayerUICanvas")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerUICancvas;
    [SerializeField] GameObject playerMain;
    [SerializeField] GameObject playerfooter;
    [SerializeField] Image playerHPBar;
    [SerializeField] Text playerHPText;
    [SerializeField] Text playerCurrentHPText;
    [SerializeField] Image playerIcon;
    [SerializeField] Text playerNameText;
    [SerializeField] Text playerLevelText;
    [SerializeField] Text playerWeaponText;
    [SerializeField] Text playerArmorText;
    [SerializeField] Text playerPetText;
    [SerializeField] Text playerFstSkillText;
    [SerializeField] Text playerSndSkillText;
    [SerializeField] Text playerTrdSkillText;
    [SerializeField] Text playerPowText;
    [SerializeField] Text playerDefText;
    [SerializeField] Text playerSpdText;
    [SerializeField] Text playerLckText;
    [SerializeField] Text playerSklText;
    [SerializeField] Text playerSumEXPText;
    [SerializeField] Text playerNextEXPText;
    [SerializeField] GameObject playerEventButton;
    [SerializeField] Text playerEventText;
    [SerializeField] Text playerGoldText;


    [Header("EnemyUICanvas")]
    [SerializeField] GameObject enemyUICanvas;
    [SerializeField] Image enemyHpBar;
    [SerializeField] Text enemyHpText;
    [SerializeField] Text enemyMaxHPText;
    [SerializeField] Image enemyIcon;
    [SerializeField] Text enemyNameText;
    [SerializeField] Text enemyLevelText;
    [SerializeField] Text enemyPowText;
    [SerializeField] Text enemyDefText;
    [SerializeField] Text enemySpdText;
    [SerializeField] Text enemyLckText;


    [Header("StageUI")]
    [SerializeField] GameObject mainTileMap;
    [SerializeField] GameObject houseArea;
    [SerializeField] GameObject weaponArea;
    [SerializeField] GameObject armorArea;
    [SerializeField] GameObject worldObjManager;
    [SerializeField] GameObject firstMapHouse;
    [SerializeField] GameObject weaponShop;
    [SerializeField] GameObject armorShop;
    [SerializeField] GameObject firstWorldObj;
    [SerializeField] GameObject secondWorldObj;
    [SerializeField] GameObject thirdWorldObj;
    [SerializeField] GameObject bossWorldObj;
    List<GameObject> houseList = new List<GameObject>();
    List<GameObject> worldObjList = new List<GameObject>();

    bool isMainArea = false;
    public bool IsMainArea
    {
        set { isMainArea = value; }
    }


    [SerializeField] GameObject mapPoint;
    EnemySpawn enemySpawn;
    CurrentMap currentMap;
    Actor actor;
    UIAudio uiAudio;




    void Awake()
    {
        enemySpawn = mapPoint.GetComponent<EnemySpawn>();
        currentMap = mapPoint.GetComponent<CurrentMap>();
        actor = player.GetComponent<Actor>();
        uiAudio = GetComponent<UIAudio>();
        SetBGList();
        SethouseList();
        SetWorldObjList();
    }
    void Start()
    {
        GameStartShowUI();
    }
    void Update()
    {
        BesideAnyAreaChecker();
        ResetEventButton();
    }

    void GameStartShowUI()
    {
        // Game���n�܂����Ƃ���UI
        isMainArea = true;
        player.SetActive(true);
        mainTileMap.SetActive(true);
        playerUICancvas.SetActive(true);
        systemMain.SetActive(true);
        systemFooter.SetActive(true);
        SpawnWorldObj(currentMap.GetMapAmount());

        if (0 < currentMap.GetMapAmount())
        {
            enemySpawn.SpawnControll(1, currentMap.GetMapAmount());
        }

        uiAudio.PlayBGM();
    }



    #region ---BGUICanvasMethod
    /// <summary>
    /// todo 1
    /// </summary>

    // �o���G�[�V�����ǉ�������K��Add()
    void SetBGList()
    {
        bgList.Add(forestBG);
        bgList.Add(desertBG);
        bgList.Add(graveyardBG);
        bgList.Add(snowBG);
    }

    void HideBG()
    {
        for (int i = 0; i < bgList.Count; i++)
        {
            bgList[i].SetActive(false);
        }
    }

    public void ChengeBG()
    {
        HideBG();
        // todo: MAP�J�E���g���Ƃɔw�i�ς���
        forestBG.SetActive(true);
    }
    #endregion


    #region ---SystemUIMethod
    /// <summary>
    /// todo 0
    /// </summary>

    public void SetLevelUpPanelText(int pow, int def, int spd, int lck, int skl, int currentHp, int staatusAddPoint)
    {
        systemPowText.text = pow.ToString();
        systemDefText.text = def.ToString();
        systemSpdText.text = spd.ToString();
        systemLckText.text = lck.ToString();
        systemSklText.text = skl.ToString();
        systemcurrentHpText.text = currentHp.ToString();
        systemStatusAddPointText.text = staatusAddPoint.ToString();
    }

    void HideSystemMenu()
    {
        systemPanel.SetActive(false);
        levelupPanel.SetActive(false);
        achievementPanel.SetActive(false);
    }
    public void ShowSystemMenu(int menuNum)
    {
        HideSystemMenu();
        playerMain.SetActive(false);
        playerfooter.SetActive(false);
        HideEnemyUI();

        uiAudio.SystemButtonSE();

        if (menuNum == 0)
        {
            if (!showSystemPanel)
            {
                showLevelupPanel = false;
                showAchievementPanel = false;
                systemPanel.SetActive(true);
                showSystemPanel = true;
            }
            else
            {
                HideSystemMenu();
                ShowEnemyUI();
                playerMain.SetActive(true);
                playerfooter.SetActive(true);
                showSystemPanel = false;
            }
        }
        else if (menuNum == 1)
        {
            if (!showLevelupPanel)
            {
                showSystemPanel = false;
                showLevelupPanel = false;
                levelupPanel.SetActive(true);
                showLevelupPanel = true;
            }
            else
            {
                HideSystemMenu();
                ShowEnemyUI();
                playerMain.SetActive(true);
                playerfooter.SetActive(true);
                showLevelupPanel = false;
            }
        }
        if (menuNum == 2)
        {
            if (!showAchievementPanel)
            {
                showSystemPanel = false;
                showSystemPanel = false;
                achievementPanel.SetActive(true);
                showAchievementPanel = true;
            }
            else
            {
                HideSystemMenu();
                ShowEnemyUI();
                playerMain.SetActive(true);
                playerfooter.SetActive(true);
                showAchievementPanel = false;
            }
        }
    }

    public void ChangeMapAmountText(int mapAmount)
    {
        mapAmountText.text = "MAP:" + mapAmount.ToString();
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
    public void HidePopupInfoFrame()
    {
        popupInfoFrame.SetActive(false);
    }
    #endregion


    #region ---PlayerUIMethod
    /// <summary>
    /// todo 2
    /// </summary>
    public void SetPlayerInfoUI(Sprite faceIcon, string name, int level)
    {
        playerIcon.sprite = faceIcon;
        playerNameText.text = name;
        playerLevelText.text = level.ToString();
    }
    // todo: ����A�h��A�y�b�g�̈������L�q����
    public void SetPlayerInventoryText()
    {
        playerWeaponText.text = string.Empty;
        playerArmorText.text = string.Empty;
        playerPetText.text = string.Empty;
    }
    // todo: �X�L��������n��
    public void SetPlayerSkillText()
    {
        playerFstSkillText.text = string.Empty;
        playerSndSkillText.text = string.Empty;
        playerTrdSkillText.text = string.Empty;
    }
    public void SetPlayerHPText(int hp, int currentHP)
    {
        playerHPText.text = hp.ToString();
        playerCurrentHPText.text = currentHP.ToString();
    }
    public void SetPlayerStatusText(int pow, int def, int spd, int lck, int skl)
    {
        playerPowText.text = pow.ToString();
        playerDefText.text = def.ToString();
        playerSpdText.text = spd.ToString();
        playerLckText.text = lck.ToString();
        playerSklText.text = skl.ToString();
    }
    public void SetPlayerEXPText(int sumtext, int nextEXP)
    {
        playerSumEXPText.text = sumtext.ToString();
        playerNextEXPText.text = nextEXP.ToString();
    }
    public void SetPlayerHPbar(int hp, int currentHp)
    {
        float hpAmount = (float)hp / (float)currentHp;
        playerHPBar.fillAmount = hpAmount;
    }
    public void SetplayerGoldText(int gold)
    {
        playerGoldText.text = gold.ToString();
    }

    void BesideAnyAreaChecker()
    {
        if (actor.IsDied) { return; }

        if (actor.BesideHouseArea || actor.BesideWeaponArea || actor.BesideArmorArea)
        {
            playerEventButton.SetActive(true);
            playerEventText.text = "����";
        }
        else { playerEventButton.SetActive(false); }
    }
    
    void ResetEventButton()
    {
        if (!actor.IsDied) { return; }
        uiAudio.StopBGM();
        playerEventText.text = "�߂�";
        playerEventButton.SetActive(true);
    }



    #endregion

    #region ---EnemyUIMethod
    public void SetEnemyInfoUI(Sprite faceIcon, string name, int level)
    {
        enemyIcon.sprite = faceIcon;
        enemyIcon.name = name;
        enemyLevelText.text = level.ToString();
    }
    public void SetEnemyHPText(int hp, int maxHp)
    {
        enemyHpText.text = hp.ToString();
        enemyMaxHPText.text = maxHp.ToString();
    }
    public void SetEnemyStatusText(int pow, int def, int spd, int lck)
    {
        enemyPowText.text = pow.ToString();
        enemyDefText.text = def.ToString();
        enemySpdText.text = spd.ToString();
        enemyLckText.text = lck.ToString();
    }
    public void SetEnemyHPbar(int hp, int maxHp)
    {
        float hpAmount = (float)hp / (float)maxHp;
        enemyHpBar.fillAmount = hpAmount;
    }

    public void HideEnemyUI()
    {
        enemyUICanvas.SetActive(false);
    }

    public void ShowEnemyUI()
    {
        if (actor.Enemy == null) { return; }

        enemyUICanvas.SetActive(true);
    }

    #endregion


    #region ---StageUIMethod
    /// <summary>
    /// todo 0
    /// </summary>
    // �o���G�[�V�����ǉ�������K��Add()
    void SethouseList()
    {
        houseList.Add(houseArea);
        houseList.Add(weaponArea);
        houseList.Add(armorArea);
    }
    void SetWorldObjList()
    {
        worldObjList.Add(firstMapHouse);
        worldObjList.Add(weaponShop);
        worldObjList.Add(armorShop);
        worldObjList.Add(firstWorldObj);
        worldObjList.Add(secondWorldObj);
        worldObjList.Add(thirdWorldObj);
        worldObjList.Add(bossWorldObj);
    }


    void HideHouseList()
    {
        for (int i = 0; i < houseList.Count; i++)
        {
            houseList[i].SetActive(false);
        }
    }
    void HideWorldObj()
    {
        for (int i = 0; i < worldObjList.Count; i++)
        {
            worldObjList[i].SetActive(false);
        }
    }
    void HideMainArea()
    {
        bgUICanvas.SetActive(false);
        playerUICancvas.SetActive(false);
        enemyUICanvas.SetActive(false);
        systemFooter.SetActive(false);
        mainTileMap.SetActive(false);
    }

    public void SpawnWorldObj(int mapCurrent)
    {
        HideWorldObj();

        if (!isMainArea) { return; }

        

        // if���̎��s������
        
        if (mapCurrent == 0 || mapCurrent % 10 == 0 && !(mapCurrent % 30 == 0))
        {
            firstMapHouse.gameObject.SetActive(true);
            return;
        }
        if (mapCurrent % 30 == 0)
        {
            bossWorldObj.gameObject.SetActive(true);
            return;
        }
        else if (mapCurrent == 2)
        {
            armorShop.gameObject.SetActive(true);
            return;
        }
        else if (mapCurrent== 1)
        {
            weaponShop.gameObject.SetActive(true);
            return;
        }
        else if (mapCurrent % 2 == 0 && !(mapCurrent == 2))
        {
            secondWorldObj.gameObject.SetActive(true);
            return;
        }
        else if (mapCurrent % 3 == 0)
        {
            thirdWorldObj.gameObject.SetActive(true);
            return;
        }
        else
        {
            firstWorldObj.gameObject.SetActive(true);
            return;
        }

    }


    void ShowAnyArea()
    {
        if (actor.BesideHouseArea)
        {
            houseArea.SetActive(true);
        }
        else if (actor.BesideWeaponArea)
        {
            weaponArea.SetActive(true);
        }
        else if (actor.BesideArmorArea)
        {
            armorArea.SetActive(true);
        }

        HideMainArea();
        player.SetActive(false);
    }
    void ShowMainArea()
    {
        HideHouseList();
        player.SetActive(true);
        bgUICanvas.SetActive(true);
        playerUICancvas.SetActive(true);
        systemFooter.SetActive(true);
        mainTileMap.SetActive(true);
    }

    #endregion

    #region ---ButtonUIMethod
    public void GoOutHouse()
    {
        isMainArea = true;
        ShowMainArea();
        ChengeBG();
        SpawnWorldObj(currentMap.GetMapAmount());
        
        enemySpawn.ShowCloneEnemy();

        uiAudio.PlayBGM();
        uiAudio.SystemButtonSE();
    }
    public void InTheHouse()
    {
        if (actor.IsDied) { return; }

        isMainArea = false;
        ShowAnyArea();
        HideWorldObj();
        enemySpawn.HideCloneEnemy();
        
        uiAudio.StopBGM();
        uiAudio.SystemButtonSE();
    }

    public void ResetButton()
    {
        if (!actor.IsDied) { return; }

        isMainArea = false;

        // UI�ύX
        houseArea.SetActive(true);
        HideWorldObj();
        HideMainArea();
        enemySpawn.CloneEnemyDestroy();

        // Player����
        player.SetActive(false);
        actor.FullHelth();
        actor.ResetActorPosition();

        // MapCurrent���Z�b�g
        currentMap.ResetMapAmount();
        ChangeMapAmountText(currentMap.GetMapAmount());

        // ���y
        uiAudio.StopBGM();
        uiAudio.SystemButtonSE();
    }

    public void StatusMinusButton(string status)
    {
        actor.DownStatus(status);
    }

    public void StatusPlusButton(string status)
    {
        actor.UpStatus(status);
    }

    public void FullHealthButton()
    {
        actor.FullHelth();
        uiAudio.FullHealthSE();
    }

    public void RightPanelDown()
    {
        actor.IsRight = true;
    }
    public void RightPanelUp()
    {
        actor.IsRight = false;
    }

    public void LeftPanelDown()
    {
        actor.IsLeft = true;
    }
    public void LeftPanelUp()
    {
        actor.IsLeft = false;
    }
    #endregion
}
