using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class CurrentMap : MonoBehaviour
{
    EndPoint endPoint;

    bool rightMapEndIsTrigger = true;
    bool leftMapEndIsTrigger;

    [SerializeField] int mapAmount = 0;
    [SerializeField] int currentMapAmount = 0;
    [SerializeField] int currentFieldAmount = 0;

    void Awake()
    {
        endPoint = GetComponent<EndPoint>();

        LoadCurrentMapDate();
    }
    void Start()
    {
    }

    public void MapFloorChange(int num)
    {
        if (num == 1)
        {
            
            mapAmount++;
            currentMapAmount++;
            this.leftMapEndIsTrigger = true;
            endPoint.LeftMapEndPointCollider.isTrigger = leftMapEndIsTrigger;

            if (mapAmount == 30)
            {
                this.rightMapEndIsTrigger = false;
                endPoint.RightMapEndPointCollider.isTrigger = rightMapEndIsTrigger;
            }
        }
        else if (num == -1)
        {
            if (mapAmount > 0)
            {
                mapAmount--;
                currentMapAmount--;
                this.rightMapEndIsTrigger = true;
                endPoint.RightMapEndPointCollider.isTrigger = rightMapEndIsTrigger;

                if (mapAmount == 0)
                {
                    this.leftMapEndIsTrigger = false;
                    endPoint.LeftMapEndPointCollider.isTrigger = leftMapEndIsTrigger;
                }

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

    public void KilledBossOfMapCurrent()
    {
        this.rightMapEndIsTrigger = false;
        this.leftMapEndIsTrigger = false ;
        endPoint.RightMapEndPointCollider.isTrigger = rightMapEndIsTrigger;
        endPoint.LeftMapEndPointCollider.isTrigger = leftMapEndIsTrigger;
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
        }
    }

    public void CurrentMapAmountMinus()
    {
        currentMapAmount -= mapAmount; 
        SaveCurrentMapDate();
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
        mapAmount = 0;
        this.rightMapEndIsTrigger = true;
        endPoint.RightMapEndPointCollider.isTrigger = rightMapEndIsTrigger;
        this.leftMapEndIsTrigger = false;
        endPoint.LeftMapEndPointCollider.isTrigger = leftMapEndIsTrigger;
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
        SaveManager.instance.SetRightMapIsTrigger(this.rightMapEndIsTrigger);
        SaveManager.instance.SetLeftMapIsTrigger(this.leftMapEndIsTrigger);
    }
    void LoadCurrentMapDate()
    {
        this.mapAmount = SaveManager.instance.GetMapAmount();
        this.currentMapAmount = SaveManager.instance.GetCurrentMapAmount();
        this.currentFieldAmount = SaveManager.instance.GetCurrentFieldAmount();
        this.rightMapEndIsTrigger = SaveManager.instance.GetRightMapIsTrigger();
        this.leftMapEndIsTrigger = SaveManager.instance.GetLeftMapIsTrigger();
        endPoint.RightMapEndPointCollider.isTrigger = rightMapEndIsTrigger;
        endPoint.LeftMapEndPointCollider.isTrigger = leftMapEndIsTrigger;
    }
}
