using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject playerInfoPanel;
    [SerializeField] GameObject weaponInventory;
    [SerializeField] GameObject armorInventory;
    [SerializeField] GameObject petInventory;

    // ItemはisHadで管理する
    // isHadがtrueなら

    // InventoryのスロットのItemのisHadがtrueなら
    // テキストを変更
    // Buttonをアクティブ

    // Buttonでやりたいこと
    // アイテムの装備(PlayerのWeaponslotの子要素にItemのPrefabを生成する)
    // 確定を押したらそのアイテムを所持する
    // 戻るを押したら前のアイテムを所持する
    // PlayerのWeaponPowにItemのWeaponPowを足す

    // Button Methods
    public void ShowWeaponInventory()
    {
        playerInfoPanel.SetActive(false);
        weaponInventory.SetActive(true);
    }

    public void ShowArmorInventory()
    {
        playerInfoPanel.SetActive(false);
        armorInventory.SetActive(true);
    }

    public void ShowPetInventory()
    {
        playerInfoPanel.SetActive(false);
        petInventory.SetActive(true);
    }

    public void HideInventory()
    {
        playerInfoPanel.SetActive(true);
        weaponInventory.SetActive(false);
        armorInventory.SetActive(false);
        petInventory.SetActive(true);
    }
}
