using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public class ItemNames
    {
        public const string coin      = "Coin";
        public const string key       = "Key";
        public const string pebble    = "Pebble";
        public const string paperclip = "Paperclip";
        public const string id        = "ID";
        public const string pill      = "Pill";
    }

    public enum Item
    {
        COIN, KEY, PEBBLE, PAPERCLIP, ID, PILL
    }

    public event Action<GameObject, List<GameObject>> AddedItem;

    private Dictionary<Item, List<GameObject>> itemSlot = new Dictionary<Item, List<GameObject>>();

    public void AddToList(GameObject item, Item itemType)
    {
        itemSlot[itemType].Add(item);
        AddedItem(item, itemSlot[itemType]);
    }

    private void Awake()
    {
        itemSlot[Item.COIN]      = new List<GameObject>();
        itemSlot[Item.KEY]       = new List<GameObject>();
        itemSlot[Item.PEBBLE]    = new List<GameObject>();
        itemSlot[Item.PAPERCLIP] = new List<GameObject>();
        itemSlot[Item.ID]        = new List<GameObject>();
        itemSlot[Item.PILL]      = new List<GameObject>();
    }
}
