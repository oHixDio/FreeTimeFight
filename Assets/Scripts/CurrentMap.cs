using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class CurrentMap : MonoBehaviour
{
    [SerializeField] int mapAmount = 0;
    [SerializeField] int currentMapAmount = 0;
    [SerializeField] int currentFieldAmount = 0;

    void Awake()
    {
        LoadCurrentMapDate();
    }

    public void MapFloorChange(int playerDirection)
    {
        if (playerDirection == 1)
        {
            
            mapAmount++;
            currentMapAmount++;
            
        }
        else if (playerDirection == -1)
        {
            if (mapAmount > 0)
            {
                mapAmount--;
                currentMapAmount--;
                
            }
            else
            {
                mapAmount = 0;
                currentMapAmount = 0;
            }
        }

        BGMChanger();
        // uiManager.SpawnWorldObj(mapAmount);

        SaveCurrentMapDate();
    }

    

    int skip = 1;
    public void SkipIncrement()
    {
        skip = 1;
    }
    public void SkipDecrement()
    {
        skip = 0;
    }

    public void CurrentFieldAmountIncrement()
    {
        if(currentFieldAmount < 5)
        {
            currentFieldAmount++;
            SaveCurrentMapDate();
        }
        else
        {
            CurrentMapAmountMinus();
            SaveCurrentMapDate();
        }
    }

    public void CurrentMapAmountMinus()
    {
        currentMapAmount -= mapAmount; 
    }

    void BGMChanger()
    {
        
        if (mapAmount == 30)
        {
            // uiManager.BossBGM();
            skip = 0;
        }
        else if (skip == 0)
        {
            skip = 1;
            // uiManager.MainBGM();
        }
    }

    public void ResetMapAmount()
    {
        CurrentMapAmountMinus();
        mapAmount = 0;
        SaveCurrentMapDate();
    }

    public int GetMapAmount()
    {
        return this.mapAmount;
    }
    public int GetCurrentMapAmount()
    {
        return this.currentMapAmount;
    }
    public int GetCurrentFieldAmount()
    {
        return this.currentFieldAmount;
    }


    void SaveCurrentMapDate()
    {
        SaveManager.instance.SetMapAmount(this.mapAmount);
        SaveManager.instance.SetCurrentMapAmount(this.currentMapAmount);
        SaveManager.instance.SetCurrentFieldAmount(this.currentFieldAmount);
    }
    void LoadCurrentMapDate()
    {
        this.mapAmount = SaveManager.instance.GetMapAmount();
        this.currentMapAmount = SaveManager.instance.GetCurrentMapAmount();
        this.currentFieldAmount = SaveManager.instance.GetCurrentFieldAmount();
    }
}
