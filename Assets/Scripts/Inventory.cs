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
        inventory = new int[numberOfUniqueItems];
        instance = this;
    }
    #endregion
    public int numberOfUniqueItems = 3;
    public int[] inventory;
    // how many items the inventory can hold
    public int inventoryCapacity;

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
    public bool AddItem(Item item)
    {
        return AddItem(item.id);
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