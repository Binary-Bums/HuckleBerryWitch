using UnityEngine;
public class InventoryItem : ScriptableObject{
    public string id;
    public Sprite sprite;
    public InventoryItem (string id, Sprite sprite)
    {
        this.id = id;
        this.sprite = sprite;
    }
}