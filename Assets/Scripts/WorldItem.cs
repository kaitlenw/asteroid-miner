using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WorldItem  : MonoBehaviour
{
    public Item item;
    void OnTriggerEnter2D (Collider2D collider)
    {
        if ((collider.gameObject.tag == "Player") && (Inventory.instance.AddItem(item)))
        {
            // GameObject matObj = collider.gameObject;
            // matObj.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
        }
    }
}