using UnityEngine;

public class Arrow : MonoBehaviour {
    private float damage;

    public void Initialize(float damage, float arrowSpeed, Vector3 shootDirection)
    {
        this.damage = damage;

        GetComponent<Rigidbody2D>().velocity = shootDirection * arrowSpeed;

        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerBody"))
        {
            // get the player's script component and call TakeDamage
            other.gameObject.GetComponentInParent<PlayerInfo>().TakeDamage(damage);;
            Destroy(gameObject);
        }
    }
}