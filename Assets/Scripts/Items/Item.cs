using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    [SerializeField] GameObject objPrefab;
    [SerializeField] string itemName;
    [SerializeField] int itemValue;
    [SerializeField] int itemSklAmount;

    public GameObject GetPrefab()
    {
        return objPrefab;
    }

    public string GetName()
    {
        return itemName;
    }

    public int GetValue()
    {
        return itemValue;
    }

    public int GetSklAmount()
    {
        return itemSklAmount;
    }
}
