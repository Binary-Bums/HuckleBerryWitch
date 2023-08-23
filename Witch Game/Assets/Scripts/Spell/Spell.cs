using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    protected Vector2 direction = new Vector2(0, 0);
    public float speed = .01f;
    public float damage = 10f;
    public float despawnTime = 15; // Time in seconds before the projectile despawns
    
    public virtual void Spawn(PlayerInfo playerInfo)
    {
        PlayerInfo.Direction playerDirection = playerInfo.direction;

        if (playerDirection == PlayerInfo.Direction.Up)
        {
            direction = new Vector2(0, speed);
        }
        else if (playerDirection == PlayerInfo.Direction.Down)
        {
            direction = new Vector2(0, -speed);
        }
        else if (playerDirection == PlayerInfo.Direction.Left)
        {
            direction = new Vector2(-speed, 0);
        }
        else if (playerDirection == PlayerInfo.Direction.Right)
        {
            direction = new Vector2(speed, 0);
        }

        Effect(playerInfo);

        // Schedule the despawn of the projectile
        Destroy(gameObject, despawnTime);

    } 

    protected virtual void Effect(PlayerInfo playerInfo) {}

    // THIS IS THE THING THAT MAKES THE SPELL HURT THINGS
    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if the spell collided with the enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            // get the player's script component and call TakeDamage
            Enemy enemyScript = other.gameObject.GetComponent<Enemy>();
            enemyScript.TakeDamage(damage);
        }
    }
}
