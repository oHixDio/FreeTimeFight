using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] GameObject rightSpawnPoint;
    [SerializeField] GameObject leftSpawnPoint;
    [SerializeField] GameObject rightEndPoint;
    [SerializeField] GameObject leftEndPoint;

    int mapAmount;
    bool rightActive;
    bool leftActive;

    void Awake()
    {
        LoadEndPoint();
    }
    void Update()
    {
        SetSpawnPoint();
    }

    void SetSpawnPoint()
    {
        rightEndPoint.SetActive(rightActive);
        leftEndPoint.gameObject.SetActive(leftActive);
    }

    public void SetEndPoint(CurrentMap map)
    {
        mapAmount = map.GetMapAmount();

        leftActive = false;
        rightActive = false;

        if (mapAmount == 0)
        {
            leftActive = true;
        }

        if (mapAmount == 30)
        {
            rightActive = true;
        }

        SaveEndPoint();
    }

    public void SpawnPlayer(GameObject player, int num)
    {
        if (num == 1)
        {
            player.transform.position = leftSpawnPoint.transform.position;
        }
        else if (num == -1)
        {
            player.transform.position = rightSpawnPoint.transform.position;
        }
    }

    void SaveEndPoint()
    {
        SaveManager.instance.SetRightEndPoint(rightActive);
        SaveManager.instance.SetLeftEndPoint(leftActive);
    }

    void LoadEndPoint()
    {
        rightActive = SaveManager.instance.GetRightEndPoint();
        leftActive = SaveManager.instance.GetLeftEndPoint();
    }




}
