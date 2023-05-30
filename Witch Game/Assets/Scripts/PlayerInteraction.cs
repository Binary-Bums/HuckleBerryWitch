using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject chestObj;
    public float interactionRange = 1f;
    private bool canInteract = false;

    public ChestToggle chestToggleScript;

    private void Start() {
        chestToggleScript = chestObj.GetComponent<ChestToggle>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == chestObj)
        {
            canInteract = true;
            // Enable interaction UI or perform desired action
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == chestObj)
        {
            canInteract = false;
            // Disable interaction UI
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject == chestObj)
    //     {
    //         // Stop the player's movement
    //         Rigidbody2D playerRigidbody = GetComponent<Rigidbody2D>();
    //         playerRigidbody.velocity = Vector2.zero;
    //     }
    // }

    private void Update()
    {
        if (canInteract && Vector2.Distance(transform.position, chestObj.transform.position) <= interactionRange)
        {
            chestToggleScript.Updatethis();
            // Handle interaction input (e.g., keyboard or mouse click) and perform desired action
        }
    }
} 