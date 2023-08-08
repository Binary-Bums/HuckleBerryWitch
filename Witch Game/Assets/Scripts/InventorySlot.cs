using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Equippable equippable;
    public void Initialize(Equippable equippable)
    {
        this.equippable = equippable;

        GetComponent<Image>().sprite = equippable.sprite;
    }   
}