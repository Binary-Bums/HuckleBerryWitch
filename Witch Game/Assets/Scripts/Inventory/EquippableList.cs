using System.Collections.Generic;

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

        else return new Equippable("");
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
            {"Glass Shard", new Item("Glass Shard")},
            {"Red Paint", new Item("Red Paint")},
            {"Blue Paint", new Item("Blue Paint")},

        };

        potionList = new Dictionary<string, Potion>()
        {
            {"Health Potion", new Potion("Health Potion")},
            {"Spell Potion", new Potion("Spell Potion")},
            {"Speed Potion", new Potion("Speed Potion")},
        };

        equippableList = new Dictionary<string, Equippable>();

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