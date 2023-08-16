using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public InventoryItem inventoryItem;

    public GameObject itemIcon;
    public GameObject deleteIcon;
    private Image imageComponent;
    private PlayerInventory playerInventory;

    public void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        if (deleteIcon != null) deleteIcon.SetActive(false);
        imageComponent = itemIcon.GetComponent<Image>();
        imageComponent.color = Color.clear;
    }

    public void Initialize(InventoryItem inventoryItem)
    {
        imageComponent = itemIcon.GetComponent<Image>();
        this.inventoryItem = inventoryItem;
        imageComponent.sprite = inventoryItem.sprite;
        imageComponent.color = Color.white;
        if (deleteIcon != null) deleteIcon.SetActive(true);
    }

    public void Reset()
    {
        inventoryItem = null;
        imageComponent.sprite = null;
        imageComponent.color = Color.clear;
        if (deleteIcon != null) deleteIcon.SetActive(false);
    }

    public void Delete()
    {
        int i = transform.GetSiblingIndex();
        playerInventory.RemoveFromInventory(i);
    }
}