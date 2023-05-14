using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPlayerImage : MonoBehaviour
{
    [SerializeField] List<Transform> weaponSlots = new List<Transform>();

    public void SetWeapon(GameObject obj)
    {
        for (int i = 0; i < weaponSlots.Count; i++)
        {
            foreach (Transform child in weaponSlots[i])
            {
                Destroy(child.gameObject);
            }
            Instantiate(obj, weaponSlots[i].position, Quaternion.identity, weaponSlots[i]);
        }
    }

    public void SetPlayerImage()
    {

    }
}
