using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName="Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public string description;
    public Sprite image;
    public int sellingPrice;

    public Item(int id, string itemName, string description, int sellingPrice)
    {
        this.id = id;
        this.itemName = itemName;
        this.description = description;
        this.image = Resources.Load<Sprite>("Sprites/" + itemName);
        this.sellingPrice = sellingPrice;
    }

    public Item(Item item) {
        this.id = item.id;
        this.itemName = item.itemName;
        this.description = item.description;
        this.image = Resources.Load<Sprite>("Sprites/" + item.itemName);
        this.sellingPrice = item.sellingPrice;
    }
}