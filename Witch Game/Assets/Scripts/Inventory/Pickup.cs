using UnityEngine;

public class Pickup : MonoBehaviour {
    public InventoryItem equippable;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("playerBody"))
            other.gameObject.GetComponentInParent<PlayerInventory>().AddToInventory(this);
    }

    public void PickedUp()
    {
        Destroy(gameObject);
    }
}