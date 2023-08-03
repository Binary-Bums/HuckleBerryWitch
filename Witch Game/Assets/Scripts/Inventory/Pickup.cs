using UnityEngine;

public class Pickup : MonoBehaviour {
    public string id;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("playerBody"))
            other.gameObject.GetComponentInParent<PlayerInventory>().AddToInventory(this);
    }
}