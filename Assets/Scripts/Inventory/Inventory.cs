using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// List‚ÉItem‚ð’Ç‰Á‚·‚é
public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    [SerializeField] List<Weapon> weaponList = new List<Weapon>();
    [SerializeField] List<Armor> armorList = new List<Armor>();
    [SerializeField] List<Pet> petList = new List<Pet>();

    public void AddWeaponList(Weapon weapon)
    {
        weaponList.Add(weapon);
    }
    public void AddArmorList(Armor armor)
    {
        armorList.Add(armor);
    }
    public void AddPetList(Pet pet)
    {
        petList.Add(pet);
    }

}

