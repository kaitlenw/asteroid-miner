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
        money = 0;
        instance = this;
        ownedUpgrades = new List<Upgrade>();
    }
    #endregion
    public int numberOfUniqueItems = 3;
    public int[] inventory;

    // how many items the inventory can hold
    public int inventoryCapacity;

    public int money;

    public List<Upgrade> ownedUpgrades;
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

    public void SellItem(Item item)
    {
        int itemProfits = item.sellingPrice * inventory[item.id];
        inventory[item.id] = 0;
        money += itemProfits;
    }

    public void BuyUpgradeItem(Upgrade upgrade)
    {
        if (money < upgrade.price)
        {
            Debug.Log("Can not buy " + upgrade.upgradeName + " - requires " + upgrade.price + " money.");
        }
        else
        {
            ownedUpgrades.Add(upgrade);
            money -= upgrade.price;
            Debug.Log("Buying " + upgrade.upgradeName + ".");
        }
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