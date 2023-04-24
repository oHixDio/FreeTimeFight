using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentMap : MonoBehaviour
{
    [SerializeField] Text mapText;

    int mapFloorAmount = 0;

    void Start()
    {
        mapText.text = "MAP : " + mapFloorAmount;
    }

    public void MapFloorChange(EndPoint e, int num)
    {
        if(num == 1)
        {
            mapFloorAmount++;
            mapText.text = "MAP : " + mapFloorAmount;
            e.MapEndPointCollider.isTrigger = true;
        }
        else if(num == -1)
        {
            if(mapFloorAmount > 0)
            {
                mapFloorAmount--;
                mapText.text = "MAP : " + mapFloorAmount;

                if(mapFloorAmount == 0)
                {
                    e.MapEndPointCollider.isTrigger = false;
                }
                
            }
            else
            {
                mapFloorAmount = 0;
                mapText.text = "MAP : " + mapFloorAmount;
            }
        }
        
    }

    public int GetMapFloorAmount()
    {
        return mapFloorAmount;
    }
}
