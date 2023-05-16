using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    // --------------------PlayerData-------------------- //
    public string playerName      { get; set; } = string.Empty;

    public int playerLevel        { get; set; } = 0;
    public int playerHp           { get; set; } = 0;
    public int playerCurrentMaxHp { get; set; } = 0;
    public int playerPow          { get; set; } = 0;
    public int playerDef          { get; set; } = 0;
    public int playerSpd          { get; set; } = 0;
    public int playerLck          { get; set; } = 0;
    public int playerSkl          { get; set; } = 0;
    public int playerSumEXP       { get; set; } = 0;
    public int playerNextEXP      { get; set; } = 0;
    public int playerGold         { get; set; } = 0;

    // --------------------MapData-------------------- //
    public int mapAmount          { get; set; } = 0;
    public int currentMapAmount   { get; set; } = 0;
    public int currentFieldAmount { get; set; } = 0;

    public bool isLeftMap         { get; set; } = false;
    public bool isRightMap        { get; set; } = false;

    // --------------------ItemData-------------------- //
    public bool[] hadItems        { get; set; } = new bool[(int)ItemType.max];  // �A�C�e���̎擾bool���

    public int hasWeaponIndex     { get; set; } = 0;                            // �������Ă���Weapon��Index���
    public int hasArmorIndex      { get; set; } = 0;                            // �������Ă���Armor��Index���
    public int hasPetIndex        { get; set; } = 0;                            // �������Ă���Pet��Index���

}
