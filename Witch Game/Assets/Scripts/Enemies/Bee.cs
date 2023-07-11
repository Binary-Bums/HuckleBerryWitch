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

    private void Update() {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        
        if( distance < range){
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);



        } else {
            System.Random rand = new System.Random();
            float temp1 = (rand.Next(1200000)-600000)%(500000);
            float temp2 = (rand.Next(1200000)-600000)%(500000);
            if(temp1 < 2 || temp2 < 2){
                transform.position = new Vector3((temp1/100000000) + transform.position.x, temp2/(100000000) + transform.position.y,2);
            }
        }
    }
}