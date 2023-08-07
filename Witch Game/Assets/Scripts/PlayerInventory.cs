using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour{
    public int maxItems = 20;
    [SerializeField] private GameObject slotPrefab;

    private List<InventorySlot> inventory = new List<InventorySlot>();

    public void AddToInventory(Pickup e, Sprite s)
    {
        if (inventory.Count < maxItems) 
        {
            GameObject slotObject = Instantiate(slotPrefab, transform);
            InventorySlot slot = slotObject.GetComponent<InventorySlot>();

            slot.Initialize(e.id, s, EquippableList.GetInstance().GetEquippable(e.id));

            inventory.Add(slot);
            
            e.PickedUp();
        }
    }

    public List<InventorySlot> GetInventory()
    {
        return inventory;
    }
}