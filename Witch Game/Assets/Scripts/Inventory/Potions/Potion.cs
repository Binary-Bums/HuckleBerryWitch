using UnityEngine;
[CreateAssetMenu(fileName = "Potion", menuName = "InventoryItem/Potion")]
public class Potion : InventoryItem
{
    public Potion(string id, Sprite sprite) : base(id, sprite)
    {
    }
}