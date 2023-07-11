using UnityEngine;

public class Bee : Enemy {
    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if the enemy collided with the player
        if (other.gameObject.CompareTag("playerBody"))
        {
            // get the player's script component and call TakeDamage
            Attack(other.gameObject.GetComponentInParent<PlayerInfo>());
            Defeated();
        }
    }

    private void Attack(PlayerInfo player)
    {
        player.TakeDamage(damage);
    }

    protected override void NeutralMovement()
    {
        System.Random rand = new System.Random();
        float temp1 = (rand.Next(12)-6);
        float temp2 = (rand.Next(12)-6);
        if(temp1 < 2 || temp2 < 2){
            transform.position = new Vector3(temp1/1000 + transform.position.x, temp2/1000 + transform.position.y,2);
        }
    }

    protected override void DetectPlayer()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}