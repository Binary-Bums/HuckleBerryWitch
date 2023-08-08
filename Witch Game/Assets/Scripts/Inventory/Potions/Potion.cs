using UnityEngine;
[CreateAssetMenu(fileName = "Potion", menuName = "Equippable/Potion")]
public class Potion : Equippable
{
    public Potion(string id, Sprite sprite) : base(id, sprite)
    {
    }
}