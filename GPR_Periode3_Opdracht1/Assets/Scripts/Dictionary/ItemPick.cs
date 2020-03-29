using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemPick : MonoBehaviour
{
    private Inventory inventory;
    private Quaternion beginRotation;

    private Inventory.Item itemType;

    private void Awake()
    {
        beginRotation = transform.GetChild(0).transform.rotation;
        inventory = FindObjectOfType<Inventory>();

        if (inventory != null)
        {
            inventory = inventory.GetComponent<Inventory>();
            itemType = SetItemType(gameObject.name);
        }
    }

    private void OnMouseOver()
    {
        //When Hovering Over Item with Mouse
        transform.GetChild(0).transform.rotation = Quaternion.Euler(transform.GetChild(0).transform.rotation.eulerAngles.x,
            transform.GetChild(0).transform.rotation.eulerAngles.y + 5.0f, transform.GetChild(0).transform.rotation.eulerAngles.z);

        transform.GetChild(1).gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        //When the Mouse Exits the Item
        transform.GetChild(0).transform.rotation = beginRotation;
        transform.GetChild(1).gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        //When the Mouse Clicks the Item
        if (inventory != null)
        {
            inventory.AddToList(gameObject, itemType);
        }

        Destroy(gameObject);
    }

    private Inventory.Item SetItemType(string name)
    {
        switch (name)
        {
            case Inventory.ItemNames.coin:
                return Inventory.Item.COIN;

            case Inventory.ItemNames.key:
                return Inventory.Item.KEY;

            case Inventory.ItemNames.pebble:
                return Inventory.Item.PEBBLE;

            case Inventory.ItemNames.paperclip:
                return Inventory.Item.PAPERCLIP;

            case Inventory.ItemNames.id:
                return Inventory.Item.ID;

            case Inventory.ItemNames.pill:
                return Inventory.Item.PILL;
        }

        return Inventory.Item.PEBBLE;
    }
}
