using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : Slot
{
    public InventoryItem inventoryItem;
    

    public GameObject itemIcon;
    public GameObject deleteIcon;
    private Image imageComponent;
    private PlayerInventory playerInventory;
    private int slotIndex;

    public void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        if (deleteIcon != null) deleteIcon.SetActive(false);
        imageComponent = itemIcon.GetComponent<Image>();
        imageComponent.color = Color.clear;
        slotIndex = transform.GetSiblingIndex();
    }

    public void Initialize(InventoryItem inventoryItem)
    {
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
        playerInventory.RemoveFromInventory(slotIndex);
        Reset();
    }

    public void Moved()
    {
        Delete();
    }

    public void OnClick()
    {
        if (inventoryItem != null && ClickedItem.Instance.GetSelectedItem() == null)
        {
            ClickedItem.Instance.SelectItem(this);
            Reset();
        }
        else if (ClickedItem.Instance.GetSelectedItem() != null && inventoryItem == null)
        {   
            playerInventory.AddToInventory(ClickedItem.Instance.GetSelectedItem(), slotIndex);
            ClickedItem.Instance.Placed(this);
        }
    }

    
}