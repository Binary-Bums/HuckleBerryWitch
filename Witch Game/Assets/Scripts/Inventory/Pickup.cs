using UnityEngine;

public class Pickup : MonoBehaviour {
    public string id;
    private SpriteRenderer sr;

    private void Start() {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("playerBody"))
            other.gameObject.GetComponentInParent<PlayerInventory>().AddToInventory(this, sr.sprite);
    }

    public void PickedUp()
    {
        Destroy(gameObject);
    }
}