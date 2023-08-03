using UnityEngine;
using System.Collections.Generic;

public class PotionList : MonoBehaviour {

    [SerializeField] private List<Potion> potionList;

    public Potion GetPotion(string key)
    {
        foreach (Potion p in potionList)
        {
            if (p.id == key) return p;
        }

        return null;
    }
}