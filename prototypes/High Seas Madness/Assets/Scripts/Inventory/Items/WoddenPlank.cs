using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoddenPlank : MonoBehaviour, IInventoryItem
{
    public Sprite itemImage;

    string IInventoryItem.name => "Wodden Plank";

    Sprite IInventoryItem.image => itemImage;

    void IInventoryItem.onPickup()
    {
        Destroy(gameObject);
    }
}
