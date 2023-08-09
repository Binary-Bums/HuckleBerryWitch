using UnityEngine;

public class ChestManager : MonoBehaviour {
    private void Awake() {
        ChestToggle.ToggleChest += ToggleChestUI;
    }

    private void Start() {
        gameObject.SetActive(false);
    }

    private void OnEnable() {
        Time.timeScale = 0;
    }

    private void OnDisable() {
        Time.timeScale = 1;
    }

    private void ToggleChestUI()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}