using UnityEngine;

public class Recipe : MonoBehaviour {
    public string[] items = new string[4];
    public Potion potion;

    public Recipe (string[] i, Potion p)
    {
        items = i;
        potion = p;
    }
}