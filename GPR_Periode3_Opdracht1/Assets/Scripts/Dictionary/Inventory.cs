using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private enum Item
    {
        COIN, KEY, PEBBLE, PAPERCLIP, ID, PILL
    }

    private Dictionary<Item, List<Item>> itemSlot;

    private void Start()
    {
        itemSlot[Item.COIN]      = new List<Item>();
        itemSlot[Item.KEY]       = new List<Item>();
        itemSlot[Item.PEBBLE]    = new List<Item>();
        itemSlot[Item.PAPERCLIP] = new List<Item>();
        itemSlot[Item.ID]        = new List<Item>();
        itemSlot[Item.PILL]      = new List<Item>();
    }
}
