using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentMap : MonoBehaviour
{
    [SerializeField] Text mapText;
    [SerializeField] GameObject uiManagerobj;
    UIManager uiManager;

    [SerializeField] int mapAmount = 0;

    void Awake()
    {
        uiManager = uiManagerobj.GetComponent<UIManager>();
    }
    void Start()
    {
        uiManager.ChengeMapAmountText(mapAmount);
    }

    public void MapFloorChange(EndPoint endPoint, int num)
    {
        if (num == 1)
        {
            mapAmount++;
            uiManager.ChengeMapAmountText(mapAmount);
            endPoint.MapEndPointCollider.isTrigger = true;
        }
        else if (num == -1)
        {
            if (mapAmount > 0)
            {
                mapAmount--;
                uiManager.ChengeMapAmountText(mapAmount);

                if (mapAmount == 0)
                {
                    endPoint.MapEndPointCollider.isTrigger = false;
                }

            }
            else
            {
                mapAmount = 0;
                uiManager.ChengeMapAmountText(mapAmount);
            }
        }
        uiManager.SpawnWorldObj(mapAmount);
    }    

    // CurrentMapを他で取得するより条件がそろっているここにメソッドを置くのが良いと思った
    public void ExceptionSpawnWorldObj()
    {
        uiManager.SpawnWorldObj(mapAmount);
    }

    public int GetMapFloorAmount()
    {
        return mapAmount;
    }
}
