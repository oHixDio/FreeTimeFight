using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemUI : MonoBehaviour
{

    [SerializeField] GameObject systemPanel;
    [SerializeField] GameObject levelupPanel;
    [SerializeField] GameObject achievementPanel;

    bool showSystemPanel = false;
    bool showLevelupPanel = false;
    bool showAchievementPanel = false;

    /*
    public void HideSystemPanel()
    {
        systemPanel.SetActive(false);
        // backToHouseButton
        backToHouseFrame.gameObject.SetActive(true);
        pressedBackToHouseFrame.gameObject.SetActive(false);
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
    */
}
