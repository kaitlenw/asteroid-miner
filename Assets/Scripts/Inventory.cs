using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory  : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found.");
            return;
        }
        inventory = new int[itemDatabase.GetNumberOfUniqueItems()];
        instance = this;
    }
    #endregion
    public ItemDatabase itemDatabase;
    public int[] inventory;
    // how many items the inventory can hold
    public int inventoryCapacity;


    void Start()
    {
    }

    // returns true if the item fits in the inventory
    public bool AddItem(int id)
    {
        if (inventory.Sum() < inventoryCapacity - 1)
        {
            inventory[id] += 1;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool AddItem(string name)
    {
        Item itemToAdd = itemDatabase.GetItem(name);
        return AddItem(itemToAdd.id);
    }


    override public string ToString() 
    {
        string inv = "";
        for (int i = 0; i < inventory.Length; i++)
        {
            inv += i + ": " + inventory[i] + ", ";
        }
        return inv;
    }
}