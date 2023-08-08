using UnityEngine;
using UnityEngine.InputSystem;

public class CraftingToggle : MonoBehaviour {
    public KeyCode key = KeyCode.C;
    [SerializeField] private GameObject craftUI;
    private bool range = false;

    private void Update() {
        if (Input.GetKeyDown(key) && range)
        {
            craftUI.SetActive(!craftUI.activeSelf);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("playerBody")) range = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("playerBody")) range = false;
    }
}