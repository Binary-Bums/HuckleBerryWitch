using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealStation : MonoBehaviour
{
    private GameObject player;

    public float heal = 100f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // check if the enemy collided with the player
        if (other.gameObject.CompareTag("Player"))
        {
            // get the player's script component and call TakeDamage
            PlayerInfo playerScript = player.gameObject.GetComponent<PlayerInfo>();
            playerScript.Heal(heal);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
