using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject playerInfoPanel;
    [SerializeField] GameObject weaponInventory;
    [SerializeField] GameObject armorInventory;
    [SerializeField] GameObject petInventory;

    // Item��isHad�ŊǗ�����
    // isHad��true�Ȃ�

    // Inventory�̃X���b�g��Item��isHad��true�Ȃ�
    // �e�L�X�g��ύX
    // Button���A�N�e�B�u

    // Button�ł�肽������
    // �A�C�e���̑���(Player��Weaponslot�̎q�v�f��Item��Prefab�𐶐�����)
    // �m����������炻�̃A�C�e������������
    // �߂����������O�̃A�C�e������������
    // Player��WeaponPow��Item��WeaponPow�𑫂�

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
