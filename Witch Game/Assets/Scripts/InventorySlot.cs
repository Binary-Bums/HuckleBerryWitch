using UnityEngine;
public class InventorySlot : MonoBehaviour
{
    public string id;
    public Sprite sprite;
    public Equippable equippable;

    public void Initialize(string id, Sprite sprite, Equippable equippable)
    {
        this.id = id;
        this.sprite = sprite;
        this.equippable = equippable;
    }
    
}
