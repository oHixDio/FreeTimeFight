using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        
        Load();
    }
    [SerializeField] SaveData saveData;

    const string SAVE_KEY = "SAVE_KEY";

    void Save()
    {
        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(SAVE_KEY, json);
    }

    void Load()
    {
        saveData = new SaveData();
        if (PlayerPrefs.HasKey(SAVE_KEY) == true)
        {
            string json = PlayerPrefs.GetString(SAVE_KEY);
            saveData = JsonUtility.FromJson<SaveData>(json);
            Debug.Log(json);
        }

    }

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

    public void SetLeftMapIsTrigger(bool leftMapEndIsTrigger)
    {
        saveData.leftMapEndIsTrigger = leftMapEndIsTrigger;
        Save();
    }
    public bool GetLeftMapIsTrigger()
    {
        return saveData.leftMapEndIsTrigger;
    }
    public void SetRightMapIsTrigger(bool rightMapEndIsTrigger)
    {
        saveData.rightMapEndIsTrigger = rightMapEndIsTrigger;
        Save();
    }
    public bool GetRightMapIsTrigger()
    {
        return saveData.rightMapEndIsTrigger;
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
}


[Serializable]
public class SaveData
{
    [Header("CurrentMap")]
    public int mapAmount;
    public int currentMapAmount;
    public int currentFieldAmount;
    public bool leftMapEndIsTrigger;
    public bool rightMapEndIsTrigger = true;

    [Header("PlayerStatus")]
    public string playerNameÅ@= "Ç‰Ç§ÇµÇ·";
    public int playerHpÅ@= 100;
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



}
