using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjUI : MonoBehaviour
{
    [SerializeField] GameObject firstMapHouse;
    [SerializeField] GameObject weaponShop;
    [SerializeField] GameObject armorShop;
    [SerializeField] GameObject firstWorldObj;
    [SerializeField] GameObject secondWorldObj;
    [SerializeField] GameObject thirdWorldObj;
    [SerializeField] GameObject bossWorldObj;

    void HideWorldObj()
    {
        firstMapHouse.SetActive(false);
        weaponShop.SetActive(false);
        armorShop.SetActive(false);
        firstWorldObj.SetActive(false);
        secondWorldObj.SetActive(false);
        thirdWorldObj.SetActive(false);
        bossWorldObj.SetActive(false);
    }

    public void ShowWorldObj()
    {
        HideWorldObj();

        int val = UIMaster.instance.CurrentMap.GetMapAmount();

        // ifï∂ÇÃé¿çsèáíçà”

        if (val == 0 || val % 10 == 0 && !(val % 30 == 0))
        {
            firstMapHouse.gameObject.SetActive(true);
            return;
        }
        if (val % 30 == 0)
        {
            bossWorldObj.gameObject.SetActive(true);
            return;
        }
        else if (val == 2)
        {
            armorShop.gameObject.SetActive(true);
            return;
        }
        else if (val == 1)
        {
            weaponShop.gameObject.SetActive(true);
            return;
        }
        else if (val % 2 == 0 && !(val == 2))
        {
            secondWorldObj.gameObject.SetActive(true);
            return;
        }
        else if (val % 3 == 0)
        {
            thirdWorldObj.gameObject.SetActive(true);
            return;
        }
        else
        {
            firstWorldObj.gameObject.SetActive(true);
            return;
        }

    }
}
