using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private const int slots = 10;
    private List<IInventoryItem> items = new List<IInventoryItem>();

    public EventHandler<InventoryEventArgs> itemAddedEventHandler;

    public void AddItem(IInventoryItem item)
    {
        if (items.Count >= slots)
        {
            return;
        }

        (item as MonoBehaviour).GetComponent<Collider2D>().enabled = false;
        items.Add(item);
        item.onPickup();

        if (itemAddedEventHandler != null)
        {
            itemAddedEventHandler(this, new InventoryEventArgs(item));
        }
    }
}
