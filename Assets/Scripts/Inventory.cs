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

    public int startCapacity;

    // how many items the inventory can hold
    public int InventoryCapacity
    {
        get 
        {
            return ownedUpgrades
                .FindAll(x => x.upgradeType == Upgrade.UpgradeType.INVENTORY_UPGRADE)
                .Sum(x => x.Amount) + startCapacity;
        } 
        // set;
    }

    public int money;

    public List<Upgrade> ownedUpgrades;

    // returns true if the item fits in the inventory
    public bool AddItem(int id)
    {
        if (Count() < InventoryCapacity - 1)
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
            // probably make a "invalid" noise
            Debug.Log("Can not buy " + upgrade.upgradeName + " - requires " + upgrade.price + " money.");
        }
        else
        {
            ownedUpgrades.Add(upgrade);
            money -= upgrade.price;
            Debug.Log("Buying " + upgrade.upgradeName + " of type " + upgrade.upgradeType.ToString() + ".");
            Debug.Log("You now have " + ownedUpgrades.FindAll(x => x.upgradeType == upgrade.upgradeType).Count + " upgrades of type " + upgrade.upgradeType.ToString());
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

    public int Count()
    {
        return inventory.Sum();
    }

    public int GetFuelUpgrade()
    {
        return ownedUpgrades.FindAll(x => x.upgradeType == Upgrade.UpgradeType.FUEL_UPGRADE).Sum(x => x.Amount);
    }
    public float GetShieldUpgrade()
    {
        return ownedUpgrades.FindAll(x => x.upgradeType == Upgrade.UpgradeType.SHIELD_UPGRADE).Sum(x => x.Amount);
    }
}