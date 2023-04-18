using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentMap : MonoBehaviour
{
    [SerializeField] Text mapText;

    int mapFloor = 0;

    void Start()
    {
        mapText.text = "MAP : " + mapFloor;
    }

    public void MapFloorChange(EndPoint e, int num)
    {
        if(num == 1)
        {
            mapFloor++;
            mapText.text = "MAP : " + mapFloor;
            e.MapEndPointCollider.isTrigger = true;
        }
        else if(num == -1)
        {
            if(mapFloor > 0)
            {
                mapFloor--;
                mapText.text = "MAP : " + mapFloor;

                if(mapFloor == 0)
                {
                    e.MapEndPointCollider.isTrigger = false;
                }
                
            }
            else
            {
                mapFloor = 0;
                mapText.text = "MAP : " + mapFloor;
            }
        }
        
    }
}
