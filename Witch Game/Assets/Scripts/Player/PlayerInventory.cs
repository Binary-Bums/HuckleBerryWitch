using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int maxItems = 20;
    private GameObject inventoryUI;

    private List<InventorySlot> inventory = new List<InventorySlot>();

    private void Awake() {
        inventoryUI = GameObject.FindGameObjectWithTag("Inventory");
    }

    public void PickUp(Pickup item)
    {
        if (inventory.Count < maxItems && GetEmptySlot() != -1)
        {
            inventoryUI.transform.GetChild(GetEmptySlot()).GetComponent<InventorySlot>().Initialize(item.inventoryItem);
            item.PickedUp();
        }
        
    }

    public void AddToInventory(InventoryItem item)
    {
        if (inventory.Count < maxItems && GetEmptySlot() != -1)
        {
            inventoryUI.transform.GetChild(GetEmptySlot()).GetComponent<InventorySlot>().Initialize(item);
        }
    }

    public void AddToInventory(InventoryItem item, int slot)
    {
        inventoryUI.transform.GetChild(slot).GetComponent<InventorySlot>().Initialize(item);
    }

    public void RemoveFromInventory(int i)
    {
        inventoryUI.transform.GetChild(i).GetComponent<InventorySlot>().Clear();
    }

    public int GetEmptySlot()
    {

        int emptySlot = -1;
        for (int i = 0; i < maxItems; i++)
        {

            if (inventoryUI.transform.GetChild(i).GetComponent<InventorySlot>().inventoryItem == null)
            {
                emptySlot = i;
                break;
            }
        }
        return emptySlot;

    }

    public List<InventorySlot> GetInventory()
    {
        return inventory;
    }
}