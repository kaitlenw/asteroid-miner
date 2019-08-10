using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;
    public Image icon;
    public Text itemCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        icon.sprite = item.image;
        icon.enabled = true;
        itemCount.text = Inventory.instance.inventory[item.id] + "";
        itemCount.enabled = true;
    }
}
