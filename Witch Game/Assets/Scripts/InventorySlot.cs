using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Equippable equippable;
    public Sprite sprite;
    public void Initialize(Equippable equippable, Sprite sprite)
    {
        this.equippable = equippable;
        this.sprite = sprite;

        GetComponent<Image>().sprite = sprite;
    }
    
}
