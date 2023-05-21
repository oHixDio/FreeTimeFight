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
    [SerializeField] GameObject systemMain;
    [SerializeField] GameObject systemFooter;
    // infoPanel
    [SerializeField] Text mapAmountText;
    [SerializeField] Text currentFieldAmountText;
    [SerializeField] GameObject popupInfoFrame;
    [SerializeField] Text popupInfoText;
    // levelupPanel
    [SerializeField] GameObject levelupPanel;
    [SerializeField] Text systemPowText;
    [SerializeField] Text systemDefText;
    [SerializeField] Text systemSpdText;
    [SerializeField] Text systemLckText;
    [SerializeField] Text systemSklText;
    [SerializeField] Text systemcurrentHpText;
    [SerializeField] Text systemStatusAddPointText;
    // systemPanel
    [SerializeField] GameObject systemPanel;
    [SerializeField] GameObject backToHouseFrame;
    [SerializeField] GameObject pressedBackToHouseFrame;
    // achievementPanel
    [SerializeField] GameObject achievementPanel;

    // infoText
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
    // hpPanel
    [SerializeField] Image playerHPBar;
    [SerializeField] Text playerHPText;
    [SerializeField] Text playerCurrentHPText;
    [SerializeField] Image playerAttackBar;
    // infoPanel
    [SerializeField] Image playerIcon;
    [SerializeField] Text playerNameText;
    [SerializeField] Text playerLevelText;
    [SerializeField] Text playerWeaponText;
    [SerializeField] Text playerArmorText;
    [SerializeField] Text playerPetText;
    [SerializeField] Text playerFstSkillText;
    [SerializeField] Text playerSndSkillText;
    [SerializeField] Text playerTrdSkillText; 
    // statusPanel
    [SerializeField] Text playerPowText;
    [SerializeField] Text playerDefText;
    [SerializeField] Text playerSpdText;
    [SerializeField] Text playerLckText;
    [SerializeField] Text playerSklText;
    [SerializeField] Text playerSumEXPText;
    [SerializeField] Text playerNextEXPText;  // Clear
    // event&GoldPanel
    [SerializeField] GameObject playerEventButton;
    [SerializeField] Text playerEventText;
    [SerializeField] Text playerGoldText;
    [SerializeField] GameObject completeFrame;


    [Header("EnemyUICanvas")]
    [SerializeField] GameObject enemyUICanvas;
    // hpPanel
    [SerializeField] Image enemyHpBar;
    [SerializeField] Text enemyHpText;
    [SerializeField] Text enemyMaxHPText;
    [SerializeField] Image enemyAttackbar;
    // infoPanel
    [SerializeField] Image enemyIcon;
    [SerializeField] Text enemyNameText;
    [SerializeField] Text enemyLevelText;
    // statusPanel
    [SerializeField] Text enemyPowText;
    [SerializeField] Text enemyDefText;
    [SerializeField] Text enemySpdText;
    [SerializeField] Text enemyLckText;


    [Header("StageUI")]
    [SerializeField] GameObject mainTileMap;
    //  areaList
    [SerializeField] GameObject houseArea;
    [SerializeField] GameObject weaponArea;
    [SerializeField] GameObject armorArea;
    // worldObj
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

    // scripts
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
        SetHouseList();
        SetWorldObjList();
    }
    void Start()
    {
        GameStartShowUI();
    }
    void Update()
    {
        BesideAnyAreaChecker();
    }

    void GameStartShowUI()
    {
        // Gameが始まったときのUI
        isMainArea = true;
        actor.IsMove = true;
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

    }



    #region ---BGUICanvasMethod
    /// <summary>
    /// todo 1
    /// </summary>

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
        for (int i = 0; i < bgList.Count; i++)
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

        HideSystemPanel();
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

    public void HideSystemPanel()
    {
        systemPanel.SetActive(false);
        // backToHouseButton
        backToHouseFrame.gameObject.SetActive(true);
        pressedBackToHouseFrame.gameObject.SetActive(false);
    }

    public void ChangeMapAmountText(int mapAmount)
    {
        mapAmountText.text = "MAP:" + mapAmount.ToString();
    }
    void ChangeCurrentFiledAmountText()
    {
        currentMap.CurrentFieldAmountIncrement();
        currentFieldAmountText.text = "F:"+ currentMap.GetCurrentFieldAmount().ToString();
    }

    // PopupUI関係
    // type => 0:null 1:nullではない
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
    public void ShowCompleteFrame()
    {
        completeFrame.SetActive(true);
    }
    void HideCompleteFrame()
    {
        completeFrame.SetActive(false);
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
    // todo: 武器、防具、ペットの引数を記述する
    public void SetPlayerInventoryText()
    {
        playerWeaponText.text = string.Empty;
        playerArmorText.text = string.Empty;
        playerPetText.text = string.Empty;
    }
    // todo: スキル引数を渡す
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
    public void SetPlayerAttackBar(float attackDeleyTime, float maxDeleyAmount)
    {
        if (actor.Enemy == null)
        {
            playerAttackBar.gameObject.SetActive(false);
        }
        else
        {
            float deleyAmount = attackDeleyTime / maxDeleyAmount;
            playerAttackBar.gameObject.SetActive(true);
            playerAttackBar.fillAmount = deleyAmount;
        }

    }
    public void SetplayerGoldText(int gold)
    {
        playerGoldText.text = gold.ToString();
    }

    void BesideAnyAreaChecker()
    {
        if (actor.BesideHouseArea || actor.BesideWeaponArea || actor.BesideArmorArea)
        {
            if (actor.IsDied || actor.IsKilledBoss) { return; }

            playerEventButton.SetActive(true);
            playerEventText.text = "入る";
        }
        else if (actor.IsDied)
        {
            uiAudio.StopBGM();
            playerEventText.text = "戻る";
            playerEventButton.SetActive(true);
        }
        else if (actor.IsKilledBoss)
        {
            actor.IsMove = false;
            playerEventText.text = "戻る";
            playerEventButton.SetActive(true);
        }
        else { playerEventButton.SetActive(false); }
    }

    // ------------------------------------------------------------------ //
    // TODO
    // 実績反映　UI作成
    // 家の回復はお金を払わないとできないようにする
    // 家のテキストを変更できるようにする　UI作成
    // ------------------------------------------------------------------ //



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
    public void SetEnemyAttackBar(float attackDeleyTime, float maxDeleyAmount)
    {
        float deleyAmount = attackDeleyTime / maxDeleyAmount;
        enemyAttackbar.fillAmount = deleyAmount;
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
    // バリエーション追加したら必ずAdd()
    void SetHouseList()
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
        else if (mapCurrent == 1)
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

    void BackToHouse()
    {
        isMainArea = false;
        actor.IsMove = false;
        actor.IsKilledBoss = false;
        actor.IsDied = false;
        // UI変更
        houseArea.SetActive(true);
        HideWorldObj();
        HideMainArea();
        enemySpawn.CloneEnemyDestroy();

        // Player調整
        player.SetActive(false);
        actor.ResetActorPosition();

        // MapCurrentリセット
        currentMap.ResetMapAmount();
        ChangeMapAmountText(currentMap.GetMapAmount());

    }

    #endregion

    #region ---ButtonUIMethod
    public void GoOutHouse()
    {
        isMainArea = true;
        actor.IsMove = true;
        ShowMainArea();
        ChengeBG();
        SpawnWorldObj(currentMap.GetMapAmount());

        enemySpawn.ShowCloneEnemy();
        // 音楽
        uiAudio.PlayMainBGM();
        uiAudio.SystemButtonSE();
    }
    public void InTheHouse()
    {
        if (actor.IsDied || actor.IsKilledBoss) { return; }

        isMainArea = false;
        actor.IsMove = false;
        ShowAnyArea();
        HideWorldObj();
        enemySpawn.HideCloneEnemy();

        uiAudio.StopBGM();
        uiAudio.SystemButtonSE();
    }
    public void ReSpawnButton()
    {
        if (actor.IsDied || actor.IsKilledBoss)
        {
            if (actor.IsDied)
            {
                actor.FullHelth();
                currentMap.CurrentMapAmountMinus();
            }

            if (actor.IsKilledBoss)
            {
                HideCompleteFrame();
                ChangeCurrentFiledAmountText();
            }

            BackToHouse();

            // 音楽
            uiAudio.StopBGM();
            uiAudio.SystemButtonSE();
        }
    }

    public void BackToHouseButton()
    {
        backToHouseFrame.gameObject.SetActive(false);
        pressedBackToHouseFrame.gameObject.SetActive(true);
        uiAudio.SystemButtonSE();
    }
    public void NoBackToHouse()
    {
        backToHouseFrame.gameObject.SetActive(true);
        pressedBackToHouseFrame.gameObject.SetActive(false);
        uiAudio.SystemButtonSE();
    }
    public void YesBackToHouse()
    {
        if (actor.IsDied || actor.IsKilledBoss) 
        {
            uiAudio.SystemErrorSE();
            return; 
        }
        currentMap.CurrentMapAmountMinus();
        BackToHouse();

        // 音楽
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
        if (!actor.IsMove && actor.Enemy != null)
        {
            actor.ShortingAttackDelay(0.1f);
        }
    }
    public void RightPanelUp()
    {
        actor.IsRight = false;
    }

    public void LeftPanelDown()
    {
        actor.IsLeft = true;
        if (!actor.IsMove && actor.Enemy != null)
        {
            actor.ShortingAttackDelay(0.01f);
        }
    }
    public void LeftPanelUp()
    {
        actor.IsLeft = false;
    }
    #endregion

    #region --- Other
    public void MainBGM()
    {
        uiAudio.PlayMainBGM();
    }
    public void BossBGM()
    {
        uiAudio.PlayBossBGM();
    }
    

    

    public void ClearChacker()
    {
        if (actor.Enemy == null) { return; }

        if (actor.Enemy.GetEnemyType() == Enemy.EnemyType.Boss)
        {
            actor.IsKilledBoss = true;
            ShowCompleteFrame();
        }
    }
    #endregion
}
