using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public InventoryItem inventoryItem;

    public GameObject itemIcon;
    public GameObject deleteIcon;
    private PlayerInventory playerInventory;

    public void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        if (deleteIcon != null) deleteIcon.SetActive(false);
    }

    public void Initialize(InventoryItem inventoryItem)
    {

        this.inventoryItem = inventoryItem;
        itemIcon.GetComponent<Image>().sprite = inventoryItem.sprite;
        if (deleteIcon != null) deleteIcon.SetActive(true);
    }

    public void Reset()
    {
        inventoryItem = null;
        itemIcon.GetComponent<Image>().sprite = null;
        if (deleteIcon != null) deleteIcon.SetActive(false);
    }

    public void Delete()
    {
        int i = transform.GetSiblingIndex();
        playerInventory.RemoveFromInventory(i);
    }
}