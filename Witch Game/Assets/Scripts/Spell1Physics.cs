using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell1Physics : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Vector2 move = new Vector2(0, 0);
    public float speed = .01f;
    public float damage = 10f;
    
    public void Spawn()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerInfo playerScript = player.gameObject.GetComponent<PlayerInfo>();
        PlayerInfo.Direction direction = playerScript.direction;

        if (direction == PlayerInfo.Direction.Up)
        {
            move = new Vector2(0, speed);
        }
        else if (direction == PlayerInfo.Direction.Down)
        {
            move = new Vector2(0, -speed);
        }
        else if (direction == PlayerInfo.Direction.Left)
        {
            move = new Vector2(-speed, 0);
        }
        else if (direction == PlayerInfo.Direction.Right)
        {
            move = new Vector2(speed, 0);
        }
    } // THIS IS THE THING THAT MAKES THE SPELL HURT THINGS
    void OnTriggerEnter2D(Collider2D other)
    {
        // check if the enemy collided with the player
        if (other.gameObject.CompareTag("Enemy"))
        {
            // get the player's script component and call TakeDamage
            Enemy enemyScript = other.gameObject.GetComponent<Enemy>();
            enemyScript.TakeDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + move.x, transform.position.y + move.y, transform.position.z);
        
    }
}
