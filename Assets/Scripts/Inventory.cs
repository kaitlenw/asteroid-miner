using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory  : MonoBehaviour
{
    public ItemDatabase itemDatabase;
    private int[] inventory;
    // how many items the inventory can hold
    public int inventoryCapacity;

    void Start()
    {
        inventory = new int[itemDatabase.GetNumberOfUniqueItems()];
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