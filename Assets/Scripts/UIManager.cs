using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [SerializeField] GameObject systemFooter;
    [SerializeField] GameObject systemPanel;
    [SerializeField] GameObject levelupPanel;
    [SerializeField] GameObject achievementPanel;
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
    [SerializeField] Text playerMaxHPText;
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
    
    



    void Awake()
    {
        SetBGList();
        SethouseList();
        SetWorldObjList();
    }
    void Start()
    {
        GameStartShowUI();
    }

    void GameStartShowUI()
    {
        // Gameが始まったときのUI
        HideBG();
        HideSystemMenu();
        ShowAnyArea(0);
    }
    

    /// <summary>
    /// todo 1
    /// </summary>
    #region ---BGUICanvasMethod
    // バリエーション追加したら必ずAdd()
    void SetBGList()
    {
        bgList.Add(forestBG);
        bgList.Add(desertBG);
        bgList.Add(graveyardBG);
        bgList.Add(snowBG);
    }

    void HideBG()
    {
        for(int i = 0; i < bgList.Count; i++)
        {
            bgList[i].SetActive(false);
        }
    }
    
    public void ChengeBG()
    {
        HideBG();
        // todo: MAPカウントごとに背景変える
        forestBG.SetActive(true);
    }
    #endregion

    /// <summary>
    /// todo 0
    /// </summary>
    #region ---SystemUIMethod
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
                playerMain.SetActive(true);
                playerfooter.SetActive(true);
                showAchievementPanel = false;
            }
        }
    }

    public void ChengeMapAmountText(int mapAmount)
    {
        mapAmountText.text = "MAP : " + mapAmount.ToString();
    }
    #endregion

    /// <summary>
    /// todo 3
    /// </summary>
    #region ---PlayerUIMethod
    void SetPlayerInfoUI(Sprite faceIcon, string name, int level)
    {
        playerIcon.sprite = faceIcon;
        playerNameText.text = name;
        playerLevelText.text = level.ToString();
    }
    // todo: 武器、防具、ペットの引数を記述する
    void SetPlayerInventoryText()
    {
        playerWeaponText.text = "";
        playerArmorText.text = "";
        playerPetText.text = "";
    }
    // todo: スキル引数を渡す
    void SetPlayerSkillText()
    {
        playerFstSkillText.text = string.Empty;
        playerSndSkillText.text = string.Empty;
        playerTrdSkillText.text = string.Empty;
    }
    void SetPlayerHPText(int hp, int maxHP)
    {
        playerHPText.text = hp.ToString();
        playerMaxHPText.text = maxHP.ToString();
    }
    void SetPlayerStatusText(int pow, int def, int spd, int lck, int skl)
    {
        playerPowText.text = pow.ToString();
        playerDefText.text = def.ToString();
        playerSpdText.text = spd.ToString();
        playerLckText.text = lck.ToString();
        playerSklText.text = skl.ToString();
    }
    void SetPlayerEXPText(int sumtext, int nextEXP)
    {
        playerSumEXPText.text = sumtext.ToString();
        playerNextEXPText.text = nextEXP.ToString();
    }
    // todo: イベント引数を渡す
    void SetPlayerEventText()
    {
        playerEventText.text = string.Empty;
    }
    void SetplayerGoldText(int gold)
    {
        playerGoldText.text = gold.ToString();
    }

    void HideEventButton()
    {
        playerEventButton.gameObject.SetActive(false);
    }

    void ShowEventButton()
    {
        playerEventButton.gameObject.SetActive(true);
    }
    #endregion

    #region ---EnemyUIMethod
    void SetEnemyInfoUI(Sprite faceIcon, string name, int level)
    {
        enemyIcon.sprite = faceIcon;
        enemyIcon.name = name;
        enemyLevelText.text = level.ToString();
    }
    void SetEnemyHPText(int hp, int maxHp)
    {
        enemyHpText.text = hp.ToString();
        enemyMaxHPText.text = maxHp.ToString();
    }
    void SetEnemyStatusText(int pow, int def, int spd, int lck)
    {
        enemyPowText.text = pow.ToString();
        enemyDefText.text = def.ToString();
        enemySpdText.text = spd.ToString();
        enemyLckText.text = lck.ToString();
    }

    void HideEnemyUI()
    {
        enemyUICanvas.SetActive(false);
    }

    void ShowEnemyUI()
    {
        enemyUICanvas.SetActive(true);
    }

    #endregion

    /// <summary>
    /// todo 0
    /// </summary>
    #region ---StageUIMethod
    // バリエーション追加したら必ずAdd()
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

        // if文の実行順注意
        if (mapCurrent == 0)
        {
            firstMapHouse.gameObject.SetActive(true);
        }
        else if (mapCurrent % 30 == 0)
        {
            bossWorldObj.gameObject.SetActive(true);
        }
        else if (mapCurrent % 10 == 0 && !(mapCurrent % 20 == 0))
        {
            weaponShop.gameObject.SetActive(true);
        }
        else if (mapCurrent % 10 == 0 && mapCurrent % 20 == 0)
        {
            armorShop.gameObject.SetActive(true);
        }
        else if (mapCurrent % 2 == 0)
        {
            secondWorldObj.gameObject.SetActive(true);
        }
        else if (mapCurrent % 3 == 0)
        {
            thirdWorldObj.gameObject.SetActive(true);
        }
        else
        {
            firstWorldObj.gameObject.SetActive(true);
        }

    }

    void ShowAnyArea(int areaNum)
    {
        isMainArea = false;
        HideMainArea();
        player.SetActive(false);
        
        if (areaNum == 0)
        {
            houseArea.SetActive(true);
        }
        else if (areaNum == 1)
        {
            houseArea.SetActive(true);
        }
        else if (areaNum == 2)
        {
            armorArea.SetActive(true);
        }
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
        ShowMainArea();
        ChengeBG();
        isMainArea = true;

    }
    #endregion
}
