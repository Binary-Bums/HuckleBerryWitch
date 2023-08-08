using System.Collections.Generic;
using UnityEngine;

public class EquippableList {
    private static EquippableList Instance;
    private IDictionary<string, Item> itemList;
    private IDictionary<string, Potion> potionList;

    private IDictionary<string, Equippable> equippableList;

    private EquippableList()
    {
        FillDictionary();
    }

    public static EquippableList GetInstance()
    {
        Instance ??= new EquippableList();

        return Instance;
    }

    public Equippable GetEquippable(string key)
    {
        if (equippableList.ContainsKey(key)) return equippableList[key];

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
        equippableList = new Dictionary<string, Equippable>();

        Item[] items = Resources.LoadAll<Item>("Items/");
        Potion[] potions = Resources.LoadAll<Potion>("Potions/");
        
        foreach (Item item in items)
        {
            itemList.Add(item.id, item);
            equippableList.Add(item.id, item);
        }

        foreach (Potion potion in potions)
        {
            potionList.Add(potion.id, potion);
            equippableList.Add(potion.id, potion);
        }
    }
}