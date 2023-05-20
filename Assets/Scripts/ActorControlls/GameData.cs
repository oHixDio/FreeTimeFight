using System.Collections;
using System.Collections.Generic;

namespace GameData
{
    public class PlayerData
    { 
        string playerName        = string.Empty;
        int    playerLevel       = 0;
        int    playerHp          = 0;
        int    playerCurrentHp   = 0;
        int    playerPow         = 0;
        int    playerDef         = 0;
        int    playerSpd         = 0;
        int    playerLck         = 0;
        int    playerSkl         = 0;
        int    playerSumExp      = 0;
        int    playerNextExp     = 0;
        int    playerGold        = 0;
        int    playerStatusPoint = 0;

        public string PlayerName        { get; set; }
        public int    PlayerLevel       { get; set; }
        public int    PlayerHp          { get; set; }
        public int    PlayerCurrentHp   { get; set; }
        public int    PlayerPow         { get; set; }
        public int    PlayerDef         { get; set; }
        public int    PlayerSpd         { get; set; }
        public int    PlayerLck         { get; set; }
        public int    PlayerSkl         { get; set; }
        public int    PlayerSumExp      { get; set; }
        public int    PlayerNextExp     { get; set; }
        public int    PlayerGold        { get; set; }
        public int    PlayerStatusPoint { get; set; }


        public PlayerData()
        {
            SaveManager.instance.LoadPlayerData(this);
        }

        public void SetPlayerData(SaveData saveData)
        {
            playerName        = saveData.PlayerName;
            playerLevel       = saveData.PlayerLevel;
            playerHp          = saveData.PlayerHp;
            playerCurrentHp   = saveData.PlayerCurrentHp;
            playerPow         = saveData.PlayerPow;
            playerDef         = saveData.PlayerDef;
            playerSpd         = saveData.PlayerSpd;
            playerLck         = saveData.PlayerLck;
            playerSkl         = saveData.PlayerSkl;
            playerSumExp      = saveData.PlayerSumExp;
            playerNextExp     = saveData.PlayerNextExp;
            playerGold        = saveData.PlayerGold;
            playerStatusPoint = saveData.PlayerStatusPoint;
        }

        /*
        public void ChangePlayerName       (string s) { playerName        = s; }
        public void ChangePlayerLevel      (int val)  { playerLevel       = val; }
        public void ChangePlayerHp         (int val)  { playerHp          = val; }
        public void ChangePlayerCurrentHp  (int val)  { playerCurrentHp   = val; }
        public void ChangePlayerPow        (int val)  { playerPow         = val; }
        public void ChangePlayerDef        (int val)  { playerDef         = val; }
        public void ChangePlayerSpd        (int val)  { playerSpd         = val; }
        public void ChangePlayerSkl        (int val)  { playerSkl         = val; }
        public void ChangePlayerSumExp     (int val)  { playerSumExp      = val; }
        public void ChangePlayerNextExp    (int val)  { playerNextExp     = val; }
        public void ChangePlayerGold       (int val)  { playerGold        = val; }
        public void ChangePlayerStatusPoint(int val)  { playerStatusPoint = val; }
        */
    }

    public class MapData
    {
        int  mapAmount          = 0;
        int  currentMapAmount   = 0;
        int  currentFieldAmount = 0;
        bool isLeftEnd          = false;
        bool isRightEnd         = false;

        public int  MapAmount          { get; set; }
        public int  CurrentMapAmount   { get; set; }
        public int  CurrentFieldAmount { get; set; }
        public bool IsLeftEnd          { get; set; }
        public bool IsRightEnd         { get; set; }

        public MapData()
        {
            SaveManager.instance.LoadMapData(this);
        }

        public void SetMapData(SaveData saveData)
        {
            mapAmount          = saveData.MapAmount;
            currentMapAmount   = saveData.CurrentMapAmount;
            currentFieldAmount = saveData.CurrentFieldAmount;
            isLeftEnd          = saveData.IsLeftEnd;
            isRightEnd         = saveData.IsRightEnd;
        }

        /*
        public void ChangeMapAmount         (int val) { mapAmount = val; }
        public void ChangeCurrentMapAmount  (int val) { currentMapAmount = val; }
        public void ChangeCurrentFieldAmount(int val) { currentFieldAmount = val; }
        public void ChangeIsLeftEnd         (bool b)  { isLeftEnd = b; }
        public void ChangeIsRightEnd        (bool b)  { isRightEnd = b; }
        */
    }

    public class ItemData
    {
        bool[] hadItems       = new bool[(int)ItemType.max];
        int    hasWeaponIndex = 0;
        int    hasArmorIndex  = 0;
        int    hasPetIndex    = 0;

        public bool[] HadItems       { get; set; }                // ƒAƒCƒeƒ€‚Ìæ“¾boolî•ñ
        public int    HasWeaponIndex { get; set; }                // Š‚µ‚Ä‚¢‚éWeapon‚ÌIndexî•ñ
        public int    HasArmorIndex  { get; set; }                // Š‚µ‚Ä‚¢‚éArmor‚ÌIndexî•ñ
        public int    HasPetIndex    { get; set; }                // Š‚µ‚Ä‚¢‚éPet‚ÌIndexî•ñ

        public ItemData() 
        {
            SaveManager.instance.LoadItemData(this);
        }

        public void SetItemData(SaveData saveData)
        {
            for (int i = 0; i < hadItems.Length; i++)
            {
                hadItems[i] = saveData.HadItems[i];
            }
            hasWeaponIndex = saveData.HasWeaponIndex;
            hasArmorIndex  = saveData.HasArmorIndex;
            hasPetIndex    = saveData.HasPetIndex;
        }

        /*
        public void ChangeHadItems      (int index, bool b) { hadItems[index] = b; }
        public void ChangeHasWeaponIndex(int val)           { hasWeaponIndex = val; }
        public void ChangeHasArmorIndex (int val)           { hasArmorIndex = val; }
        public void ChangeHasPetIndex   (int val)           { hasPetIndex = val; }
        */
    }
}
