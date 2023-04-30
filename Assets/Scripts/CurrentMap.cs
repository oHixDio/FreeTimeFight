using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class CurrentMap : MonoBehaviour
{
    [SerializeField] Text mapText;
    [SerializeField] GameObject uiManagerobj;
    UIManager uiManager;
    EndPoint endPoint;

    bool rightMapEndIsTrigger = true;
    bool leftMapEndIsTrigger;

    [SerializeField] int mapAmount = 0;

    void Awake()
    {
        uiManager = uiManagerobj.GetComponent<UIManager>();
        endPoint = GetComponent<EndPoint>();

        LoadCurrentMapDate();
    }
    void Start()
    {
        uiManager.ChangeMapAmountText(mapAmount);
    }

    public void MapFloorChange(int num)
    {
        if (num == 1)
        {
            
            mapAmount++;
            uiManager.ChangeMapAmountText(mapAmount);
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
                uiManager.ChangeMapAmountText(mapAmount);
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
                uiManager.ChangeMapAmountText(mapAmount);
            }
        }

        uiManager.SpawnWorldObj(mapAmount);

        SaveCurrentMapDate();
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


    void SaveCurrentMapDate()
    {
        SaveManager.instance.SetMapAmount(this.mapAmount);
        SaveManager.instance.SetRightMapIsTrigger(this.rightMapEndIsTrigger);
        SaveManager.instance.SetLeftMapIsTrigger(this.leftMapEndIsTrigger);
    }
    void LoadCurrentMapDate()
    {
        this.mapAmount = SaveManager.instance.GetMapAmount();
        this.rightMapEndIsTrigger = SaveManager.instance.GetRightMapIsTrigger();
        this.leftMapEndIsTrigger = SaveManager.instance.GetLeftMapIsTrigger();
        endPoint.RightMapEndPointCollider.isTrigger = rightMapEndIsTrigger;
        endPoint.LeftMapEndPointCollider.isTrigger = leftMapEndIsTrigger;
    }
}
