using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShopItem : MonoBehaviour
{
    [SerializeField] Text saleItemText;
    [SerializeField] GameObject saleItemInfoPanel;
    [SerializeField] Text infoAmountText;
    [SerializeField] Text infoItemNameText;
    bool isBought;

    void OnEnable()
    {
        // �w���㏈��
    }

    public void Onthis()
    {
        BuyButton.instance.SetShopItem(this);
        
    }


    public abstract void BuyItem();
    
}
