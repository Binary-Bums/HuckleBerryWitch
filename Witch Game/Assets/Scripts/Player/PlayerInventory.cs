using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int maxItems = 20;
    [SerializeField] private GameObject inventoryUI;



    private List<InventorySlot> inventory = new List<InventorySlot>();

    public void AddToInventory(Pickup e)
    {
        if (inventory.Count < maxItems)
        {
            GameObject slotObject = Instantiate(slotPrefab, transform);
            InventorySlot slot = slotObject.GetComponent<InventorySlot>();

            slot.Initialize(e.inventoryItem);

            inventory.Add(slot);

            e.PickedUp();
        }
    }

    public void AddToInventory(InventoryItem e)
    {
        if (inventory.Count < maxItems)
        {
            GameObject slotObject = Instantiate(slotPrefab, transform);
            InventorySlot slot = slotObject.GetComponent<InventorySlot>();

            slot.Initialize(e);

            inventory.Add(slot);

            if (isEmptySlot() != -1)
            {
                inventoryUI.transform.GetChild(isEmptySlot()).GetComponent<InventorySlot>().Initialize(e);
            }
        }
    }

    public void RemoveFromInventory(InventoryItem e)
    {
        InventorySlot current = null;

        foreach (InventorySlot i in inventory)
        {
            if (i.inventoryItem == e)
            {
                current = i;
                break;
            }
        }

        if (current != null) inventory.Remove(current);
    }

    public int isEmptySlot()
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
        Debug.Log(emptySlot);
        return emptySlot;

    }

    public List<InventorySlot> GetInventory()
    {
        return inventory;
    }
}