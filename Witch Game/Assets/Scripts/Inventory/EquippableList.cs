using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EquippableList : MonoBehaviour {
    public static EquippableList Instance { get; private set; }
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
        itemList = new Dictionary<string, Item>()
        {
            {"Glass Shard", new Item()},
            {"Red Paint", new Item()}

        };

        potionList = new Dictionary<string, Potion>()
        {
            {"Health Potion", new Potion()},
        };

        foreach (var pair in itemList)
        {
            equippableList.Add(pair.Key, pair.Value);
        }

        foreach (var pair in potionList)
        {
            equippableList.Add(pair.Key, pair.Value);
        }
    }
}