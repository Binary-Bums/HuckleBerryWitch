using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour{
    public int maxItems = 20;
    [SerializeField] private GameObject slotPrefab;

    private List<InventorySlot> inventory = new List<InventorySlot>();

    public void AddToInventory(Pickup e)
    {
        if (inventory.Count < maxItems) 
        {
            GameObject slotObject = Instantiate(slotPrefab, transform);
            InventorySlot slot = slotObject.GetComponent<InventorySlot>();

            slot.Initialize(e.equippable);

            inventory.Add(slot);
            
            e.PickedUp();
        }
    }

    public void AddToInventory(Equippable e)
    {
        if (inventory.Count < maxItems) 
        {
            GameObject slotObject = Instantiate(slotPrefab, transform);
            InventorySlot slot = slotObject.GetComponent<InventorySlot>();

            slot.Initialize(e);

            inventory.Add(slot);
        }
    }

    public void RemoveFromInventory(Equippable e)
    {
        InventorySlot current = null;

        foreach (InventorySlot i in inventory)
        {
            if (i.equippable == e)
            {
                current = i;
                break;
            }
        }

        if (current != null) inventory.Remove(current);
    }

    public List<InventorySlot> GetInventory()
    {
        return inventory;
    }
}