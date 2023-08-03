using UnityEngine;

public class Recipe : MonoBehaviour {
    public Item[] items = new Item[4];
    public Potion potion;

    public Recipe (Item[] i, Potion p)
    {
        items = i;
        potion = p;
    }
}