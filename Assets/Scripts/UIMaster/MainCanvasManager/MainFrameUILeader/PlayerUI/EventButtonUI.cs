using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventButtonUI : MonoBehaviour
{
    [SerializeField] Actor actor;
    [SerializeField] Text buttonText;

    public void ShowThis()
    {
        gameObject.SetActive(true);
        
    }

    public void HideThis()
    {
        gameObject.SetActive(false);
    }

    public void ShowAnyArea()
    {
        if(actor.IsDied || actor.IsKilledBoss) { return; }

        if (actor.BesideHouseArea)
        {
            UIMaster.instance.MainManager.ShopUI.ShowHealHouse();
        }
        if (actor.BesideArmorArea)
        {
            UIMaster.instance.MainManager.ShopUI.ShowArmorShop();
        }
        if (actor.BesideWeaponArea)
        {
            UIMaster.instance.MainManager.ShopUI.ShowWeaponShop();
        }
        
    }

}
