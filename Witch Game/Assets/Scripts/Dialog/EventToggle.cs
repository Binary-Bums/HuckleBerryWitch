using System;
using UnityEngine;

public class EventToggle : MonoBehaviour{
    public Dialog dialog;
    public static Action<Dialog> SendDialog;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("playerBody"))
        {
            SendDialog?.Invoke(dialog);
            Destroy(gameObject);
        }
    }
}