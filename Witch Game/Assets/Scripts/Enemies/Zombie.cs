using UnityEngine;

public class Zombie : Enemy {

    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if the enemy collided with the player
        if (other.gameObject.CompareTag("playerBody"))
        {
            // get the player's script component and call TakeDamage
            Attack(other.gameObject.GetComponentInParent<PlayerInfo>());
            nextAttackTime = Time.time + hitCooldown;
        }
    }

    private void Attack(PlayerInfo player)
    {
        player.TakeDamage(damage);
    }

    protected override void DetectPlayer()
    {
        if (nextAttackTime < Time.time)
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }
}