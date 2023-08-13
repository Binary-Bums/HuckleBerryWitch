using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public InventoryItem inventoryItem;

    public GameObject itemIcon;

    public void Start()
    {
        itemIcon.GetComponent<Image>().sprite = inventoryItem.sprite;
    }

    public void Initialize(InventoryItem inventoryItem)
    {

        this.inventoryItem = inventoryItem;
        itemIcon.GetComponent<Image>().sprite = inventoryItem.sprite;


    }
}