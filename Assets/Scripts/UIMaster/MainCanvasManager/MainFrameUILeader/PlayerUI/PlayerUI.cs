using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] GameObject playerStatusPanel;
    [SerializeField] GameObject playerInfoPanel;
    [SerializeField] GameObject playerInventoryPanel;
    [SerializeField] GameObject playerGoldPanel;
    [SerializeField] GameObject playerEventPanel;

    public void HidePlayerUI()
    {
        playerStatusPanel.SetActive(false);
        playerInfoPanel.SetActive(false);
        playerInventoryPanel.SetActive(false);
        playerGoldPanel.SetActive(false);
        playerEventPanel.SetActive(false);
    }

    // defaultでよく使う
    public void ShowMainPanel()
    {
        HidePlayerUI();

        playerStatusPanel.SetActive(true);
        playerInfoPanel.SetActive(true);
        playerGoldPanel.SetActive(false);
    }

    // EnemyStatusを表示するとき
    public void ShowStatusPanel()
    {
        playerStatusPanel.SetActive(true);
    }
    public void HideStatusPanel()
    {
        playerStatusPanel.SetActive(false);
    }

    // InventoryのButtonで使用
    public void ShowInventory()
    {
        playerInfoPanel.SetActive(false);
        playerInventoryPanel.SetActive(true);
    }
    public void HideInventory()
    {
        playerInfoPanel.SetActive(true);
        playerInventoryPanel.SetActive(false);
    }

    // PlayerのDoor当たり判定に使用
    public void ShowEventPanel()
    {
        playerEventPanel.SetActive(true);
    }
    public void HideEventPanel()
    {
        playerEventPanel.SetActive(false);

    }
}
