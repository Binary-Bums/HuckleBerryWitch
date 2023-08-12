using System.Collections.Generic;
using UnityEngine;

public class InventoryItemList {
    private static InventoryItemList Instance;
    private IDictionary<string, Item> itemList;
    private IDictionary<string, Potion> potionList;

    private IDictionary<string, InventoryItem> inventoryItemList;

    private InventoryItemList()
    {
        FillDictionary();
    }

    public static InventoryItemList GetInstance()
    {
        Instance ??= new InventoryItemList();

        return Instance;
    }

    public InventoryItem GetEquippable(string key)
    {
        if (inventoryItemList.ContainsKey(key)) return inventoryItemList[key];

        else return null;
    }

    public Item GetItem(string key)
    {
        if (itemList.ContainsKey(key)) return itemList[key];

        else return null;
    }

    public Potion GetPotion(string key)
    {
        if (potionList.ContainsKey(key)) return potionList[key];

        else return null;
    }

    private void FillDictionary()
    {
        itemList = new Dictionary<string, Item>();
        potionList = new Dictionary<string, Potion>();
        inventoryItemList = new Dictionary<string, InventoryItem>();

        Item[] items = Resources.LoadAll<Item>("Items/");
        Potion[] potions = Resources.LoadAll<Potion>("Potions/");
        
        foreach (Item item in items)
        {
            itemList.Add(item.id, item);
            inventoryItemList.Add(item.id, item);
        }

        foreach (Potion potion in potions)
        {
            potionList.Add(potion.id, potion);
            inventoryItemList.Add(potion.id, potion);
        }
    }
}