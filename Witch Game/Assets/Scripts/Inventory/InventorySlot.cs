using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public InventoryItem inventoryItem;
    public void Initialize(InventoryItem inventoryItem)
    {
        this.inventoryItem = inventoryItem;

        GetComponent<Image>().sprite = inventoryItem.sprite;
    }   
}