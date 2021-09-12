using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        inventoryManager.itemAddedEventHandler += HudControllerItemAddedHandler;
    }

    private void HudControllerItemAddedHandler(object sender, InventoryEventArgs args)
    {
        Transform panel = transform.Find("InventoryPanel");
        foreach(Transform slot in panel)
        {
            Image image = slot.GetChild(0).GetComponent<Image>();
            if (!image.enabled)
            {
                image.sprite = args.item.image;
                image.enabled = true;
                break;
            }
        }
    }
}
