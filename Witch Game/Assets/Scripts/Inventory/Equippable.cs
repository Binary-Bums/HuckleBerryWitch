using UnityEngine;
public class Equippable : ScriptableObject{
    public string id;
    public Sprite sprite;
    public Equippable (string id, Sprite sprite)
    {
        this.id = id;
        this.sprite = sprite;
    }
}