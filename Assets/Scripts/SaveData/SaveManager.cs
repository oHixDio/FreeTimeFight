using GameData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.VisualScripting;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        JsonDataLoad();
    }

    [SerializeField] SaveData saveData;

    const string SAVE_KEY = "SAVE_KEY";

    void JsonDataSave()
    {
        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(SAVE_KEY, json);
    }

    void JsonDataLoad()
    {
        saveData = new SaveData();
        if (PlayerPrefs.HasKey(SAVE_KEY) == true)
        {
            string json = PlayerPrefs.GetString(SAVE_KEY);
            saveData = JsonUtility.FromJson<SaveData>(json);
            Debug.Log(json);
        }

    }

    public void LoadPlayerData(GameData.PlayerData playerData)
    {
        playerData.SetPlayerData(saveData);
    }

    public void LoadMapData(GameData.MapData mapData)
    {
        mapData.SetMapData(saveData);
    }

    public void LoadItemData(GameData.ItemData itemData)
    {
        itemData.SetItemData(saveData);
    }

    public void SavePlayerData(GameData.PlayerData playerData)
    {
        saveData.SetPlayerData(playerData);
        JsonDataSave();
    }

    public void SaveMapData(GameData.MapData mapData)
    {
        saveData.SetMapData(mapData);
        JsonDataSave();
    }

    public void SaveItemData(GameData.ItemData itemData)
    {
        saveData.SetItemData(itemData);
        JsonDataSave();
    }


    /*
    #region

    public void SetMapAmount(int mapAmount)
    {
        saveData.mapAmount = mapAmount;
        Save();
    }
    public int GetMapAmount()
    {
        return saveData.mapAmount;
    }

    public void SetCurrentMapAmount(int currentmapAmount)
    {
        saveData.currentMapAmount = currentmapAmount;
        Save();
    }
    public int GetCurrentMapAmount()
    {
        return saveData.currentMapAmount;
    }

    public void SetCurrentFieldAmount(int currentFieldAmount)
    {
        saveData.currentFieldAmount = currentFieldAmount;
        Save();
    }
    public int GetCurrentFieldAmount()
    {
        return saveData.currentFieldAmount;
    }

    public void SetLeftEndPoint(bool leftActive)
    {
        saveData.leftEndPoint = leftActive;
        Save();
    }
    public bool GetLeftEndPoint()
    {
        return saveData.leftEndPoint;
    }
    public void SetRightEndPoint(bool rightActive)
    {
        saveData.rightEndPoint = rightActive;
        Save();
    }
    public bool GetRightEndPoint()
    {
        return saveData.rightEndPoint;
    }

    public void SetPlayerName(string name)
    {
        saveData.playerName = name;
        Save();
    }
    public string GetPlayerName()
    {
        return saveData.playerName;
    }

    public void SetPlayerHp(int hp)
    {
        saveData.playerHp = hp;
        Save();
    }
    public int GetPlayerHp()
    {
        return saveData.playerHp;
    }

    public void SetPlayerCurrentHp(int currentHp)
    {
        saveData.playerCurrentHp = currentHp;
        Save();
    }
    public int GetPlayerCurrentHp()
    {
        return saveData.playerCurrentHp;
    }

    public void SetPlayerLevel(int level)
    {
        saveData.playerLevel = level;
        Save();
    }
    public int GetPlayerLevel()
    {
        return saveData.playerLevel;
    }

    public void SetPlayerPow(int pow)
    {
        saveData.playerPow = pow;
        Save();
    }
    public int GetPlayerPow()
    {
        return saveData.playerPow;
    }

    public void SetPlayerDef(int def)
    {
        saveData.playerDef = def;
        Save();
    }
    public int GetPlayerDef()
    {
        return saveData.playerDef;
    }

    public void SetPlayerSpd(int spd)
    {
        saveData.playerSpd = spd;
        Save();
    }
    public int GetPlayerSpd()
    {
        return saveData.playerSpd;
    }

    public void SetPlayerLck(int lck)
    {
        saveData.playerLck = lck;
        Save();
    }
    public int GetPlayerLck()
    {
        return saveData.playerLck;
    }

    public void SetPlayerSkl(int skl)
    {
        saveData.playerSkl = skl;
        Save();
    }
    public int GetPlayerSkl()
    {
        return saveData.playerSkl;
    }

    public void SetPlayerSumExp(int sumExp)
    {
        saveData.playerSumExp = sumExp;
        Save();
    }
    public int GetPlayerSumExp()
    {
        return saveData.playerSumExp;
    }

    public void SetPlayerNextExp(int nextExp)
    {
        saveData.playerNextExp = nextExp;
        Save();
    }
    public int GetPlayerNextExp()
    {
        return saveData.playerNextExp;
    }

    public void SetPlayerGold(int gold)
    {
        saveData.playerGold = gold;
        Save();
    }
    public int GetPlayerGold()
    {
        return saveData.playerGold;
    }

    public void SetPlayerStatusAddPoint(int statusAddPoint)
    {
        saveData.playerStatusAddPoint = statusAddPoint;
        Save();
    }
    public int GetPlayerStatusAddPoint()
    {
        return saveData.playerStatusAddPoint;
    }
    
    #endregion
    */
}


[Serializable]
public class SaveData
{
    string playerName      = string.Empty;
    int playerLevel        = 0;
    int playerHp           = 0;
    int playerCurrentHp    = 0;
    int playerPow          = 0;
    int playerDef          = 0;
    int playerSpd          = 0;
    int playerLck          = 0;
    int playerSkl          = 0;
    int playerSumExp       = 0;
    int playerNextExp      = 0;
    int playerGold         = 0;
    int playerStatusPoint  = 0;


    int mapAmount          = 0;
    int currentMapAmount   = 0;
    int currentFieldAmount = 0;
    bool isLeftEnd         = false;
    bool isRightEnd        = false;
    bool[] hadItems        = new bool[(int)ItemType.max];
    int hasWeaponIndex     = 0;
    int hasArmorIndex      = 0;
    int hasPetIndex        = 0;

    public string PlayerName      { get; }
    public int PlayerLevel        { get; }
    public int PlayerHp           { get; }
    public int PlayerCurrentHp    { get; }
    public int PlayerPow          { get; }
    public int PlayerDef          { get; }
    public int PlayerSpd          { get; }
    public int PlayerLck          { get; }
    public int PlayerSkl          { get; }
    public int PlayerSumExp       { get; }
    public int PlayerNextExp      { get; }
    public int PlayerGold         { get; }
    public int PlayerStatusPoint  { get; }
    public int MapAmount          { get; }
    public int CurrentMapAmount   { get; }
    public int CurrentFieldAmount { get; }
    public bool IsLeftEnd         { get; }
    public bool IsRightEnd        { get; }
    public bool[] HadItems        { get; }                // アイテムの取得bool情報
    public int HasWeaponIndex     { get; }                // 所持しているWeaponのIndex情報
    public int HasArmorIndex      { get; }                // 所持しているArmorのIndex情報
    public int HasPetIndex        { get; }                // 所持しているPetのIndex情報

    public void SetPlayerData(GameData.PlayerData playerData)
    {
        playerName        = playerData.PlayerName;
        playerLevel       = playerData.PlayerLevel;
        playerHp          = playerData.PlayerHp;
        playerCurrentHp   = playerData.PlayerCurrentHp;
        playerPow         = playerData.PlayerPow;
        playerDef         = playerData.PlayerDef;
        playerSpd         = playerData.PlayerSpd;
        playerLck         = playerData.PlayerLck;
        playerSkl         = playerData.PlayerSkl;
        playerSumExp      = playerData.PlayerSumExp;
        playerNextExp     = playerData.PlayerNextExp;
        playerGold        = playerData.PlayerGold;
        playerStatusPoint = playerData.PlayerStatusPoint;
    }

    public void SetMapData(GameData.MapData mapData)
    {
        mapAmount          = mapData.MapAmount;
        currentMapAmount   = mapData.CurrentMapAmount;
        currentFieldAmount = mapData.CurrentFieldAmount;
        isLeftEnd          = mapData.IsLeftEnd;
        isRightEnd         = mapData.IsRightEnd;
    }

    public void SetItemData(GameData.ItemData itemData)
    {
        for (int i = 0; i < hadItems.Length; i++)
        {
            hadItems[i] = itemData.HadItems[i];
        }
        hasWeaponIndex = itemData.HasWeaponIndex;
        hasArmorIndex  = itemData.HasArmorIndex;
        hasPetIndex    = itemData.HasPetIndex;
    }


    #region
    /*
    [Header("CurrentMap")]
    public int mapAmount;
    public int currentMapAmount;
    public int currentFieldAmount;
    public bool leftEndPoint;
    public bool rightEndPoint;

    [Header("PlayerStatus")]
    public string playerName　= "ゆうしゃ";
    public int playerHp　= 100;
    public int playerCurrentHp = 100;
    public int playerLevel = 1;
    public int playerPow = 5; 
    public int playerDef = 5;
    public int playerSpd = 5;
    public int playerLck = 5;
    public int playerSkl = 20;
    public int playerSumExp = 0;
    public int playerNextExp = 10;
    public int playerGold = 0;
    public int playerStatusAddPoint = 0;
    */
    #endregion

}
