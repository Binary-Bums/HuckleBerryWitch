using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    public int maxItems = 20;

    private List<Pickup> inventory = new List<Pickup>();

    private void Start() {
        
    }

    public void AddToInventory(GameObject e)
    {
        if (inventory.Count < maxItems) 
        {
            inventory.Add(e.GetComponent<Pickup>());
            Destroy(e);
        }
    }
}