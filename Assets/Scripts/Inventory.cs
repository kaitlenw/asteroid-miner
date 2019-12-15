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
        sellingList = new Item[numberOfUniqueItems];
        money = 0;
        instance = this;
    }
    #endregion
    public int numberOfUniqueItems = 3;
    public int[] inventory;
    public Item[] sellingList;
    // how many items the inventory can hold
    public int inventoryCapacity;

    public int money;

    // returns true if the item fits in the inventory
    public bool AddItem(int id)
    {
        if (Count() < inventoryCapacity - 1)
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

    public void ResetSellingList()
    {
        sellingList = new Item[numberOfUniqueItems];
    }

    public string GetSalesSummary()
    {
        string summary = "";
        int total = 0;
        foreach (Item item in sellingList)
        {
            if (item != null)
            {
                int itemProfits = item.sellingPrice * inventory[item.id];
                summary += item.itemName + ": " +item.sellingPrice + " * " + inventory[item.id] + " = " + itemProfits + "\n";
                total += itemProfits;
            }
        }
        if (summary.Length > 0)
        {
            summary += "Total Profits:   <sprite=0>" + total;
        }
        else
        {
            summary = "No items selected for sale.";
        }
        return summary;
    }

    public void SellSelectedItems()
    {
        int total = 0;
        foreach (Item item in sellingList)
        {
            if (item != null)
            {
                int itemProfits = item.sellingPrice * inventory[item.id];
                inventory[item.id] = 0;

                total += itemProfits; 
            }
        }
        money += total;
        ResetSellingList();
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

    public int Count() {
        return inventory.Sum();
    }
}