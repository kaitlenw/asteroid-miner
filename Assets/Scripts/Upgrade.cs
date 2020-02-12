using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName="Inventory/Upgrade")]
public class Upgrade : ScriptableObject
{
    public int id;
    public string upgradeName;
    public string description;
    public Sprite image;
    public int price;

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