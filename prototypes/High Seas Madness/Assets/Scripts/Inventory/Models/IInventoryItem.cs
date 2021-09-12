using System;
using UnityEngine;

public interface IInventoryItem
{
    string name { get; }
    Sprite image { get; }
    void onPickup();
}

public class InventoryEventArgs : EventArgs
{
    public IInventoryItem item;
    public InventoryEventArgs(IInventoryItem item)
    {
        this.item = item;
    }
}
