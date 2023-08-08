using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Equippable/Item")]
public class Item : Equippable
{
    public Item(string id, Sprite sprite) : base(id, sprite)
    {
    }
}