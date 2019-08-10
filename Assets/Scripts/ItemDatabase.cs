using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemDatabase  : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }
    void BuildDatabase()
    {
        items = new List<Item>() 
        {
            new Item(0, "bronze", "A very common material, with many uses.", 25),
            new Item(1, "silver", "A fairly common material, valued by many.", 50),
            new Item(2, "gold", "A rare material, many would pay good money to obtain.", 100)};
    }
    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string name)
    {
        return items.Find(item => item.itemName == name);
    }

    public int GetNumberOfUniqueItems()
    {
        return items.Count;
    }
}