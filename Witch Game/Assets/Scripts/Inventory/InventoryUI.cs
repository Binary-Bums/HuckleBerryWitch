using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private PlayerInventory playerInventory;

    private void Start() {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    
}
