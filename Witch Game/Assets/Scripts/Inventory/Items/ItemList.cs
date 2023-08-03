using UnityEngine;
using System.Collections.Generic;

public class ItemList : MonoBehaviour {

    [SerializeField] private List<Item> itemList;

    public Item GetItem(string key)
    {
        foreach (Item i in itemList)
        {
            if (i.id == key) return i;
        }

        return null;
    }
}