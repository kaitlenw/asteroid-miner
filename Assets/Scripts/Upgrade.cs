using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName="Inventory/Upgrade")]
public class Upgrade : ScriptableObject
{

    public enum UpgradeType
    {
        SHIELD_UPGRADE,
        FUEL_UPGRADE,
        LASER_UPGRADE,
        INVENTORY_UPGRADE,
    }

    public int id;
    public string upgradeName;
    public string description;
    public Sprite image;
    public int price;

    // how much the upgrade improves things by (e.g extra amount of fuel, extra inventory spaces - may need to change later for more complex upgrades)

    [SerializeField]
    private int amount;
    public int Amount
    {
        get
        {
            return amount;
        }
        set
        {
            amount = value;
        }
    }

    public UpgradeType upgradeType;

    public Upgrade(int id, string upgradeName, string description, int price)
    {
        this.id = id;
        this.upgradeName = upgradeName;
        this.description = description;
        this.image = Resources.Load<Sprite>("Sprites/" + upgradeName);
        this.price = price;
    }

    public Upgrade(Upgrade upgrade) {
        this.id = upgrade.id;
        this.upgradeName = upgrade.upgradeName;
        this.description = upgrade.description;
        this.image = Resources.Load<Sprite>("Sprites/" + upgrade.upgradeName);
        this.price = upgrade.price;
    }
}