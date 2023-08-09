using UnityEngine;

public class ChestToggle : MonoBehaviour
{
    public KeyCode key = KeyCode.C;
    public static event System.Action ToggleChest;
    private bool range = false;

    private void Update() {
        if (Input.GetKeyDown(key) && range)
        {
            ToggleChest?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("playerBody")) range = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("playerBody")) range = false;
    }
}