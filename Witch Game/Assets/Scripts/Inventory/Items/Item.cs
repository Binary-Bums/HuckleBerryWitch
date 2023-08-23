using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "InventoryItem/Item")]
public class Item : InventoryItem
{
    public Item(string id, Sprite sprite) : base(id, sprite)
    {
    }
}