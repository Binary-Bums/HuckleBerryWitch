using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    public int maxItems = 20;

    private List<Equippable> inventory = new List<Equippable>();

    private void Start() {
        
    }

    public void AddToInventory(Pickup e)
    {
        if (inventory.Count < maxItems) 
        {
            inventory.Add(EquippableList.GetInstance().GetEquippable(e.id));
            Destroy(e.gameObject);

            foreach (Equippable equippable in inventory)
            {
                Debug.Log(equippable);
            }
        }
    }
}