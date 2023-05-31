using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject spell1;
    [SerializeField] private float damageAmount = 30f;
    [SerializeField] private float attackRadius = 1.5f;
    [SerializeField] public float attackCooldown = 1f;
    [SerializeField] private bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // check if the enemy collided with the player
        if (other.gameObject.CompareTag("Enemy"))
        {
            // get the player's script component and call TakeDamage
            Enemy enemyScript = other.gameObject.GetComponent<Enemy>();
            enemyScript.TakeDamage(damageAmount);
        }
    }

    private void MeleeAttack()
    {
        // Check if the player can attack
        if (!canAttack)
            return;

        // Detect nearby objects within the attack range
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, attackRadius);

        // Apply damage to the detected objects
        foreach (Collider2D obj in hitObjects)
        {
            // Check if the object has a health component or tag
            if (obj.gameObject.CompareTag("Enemy"))
            {
                Enemy enemyScript = obj.gameObject.GetComponent<Enemy>();
                enemyScript.TakeDamage(damageAmount);
            }
        }

        // Disable the ability to attack temporarily
        canAttack = false;
        Invoke(nameof(ResetAttack), attackCooldown);
    }

    private void ResetAttack()
    {
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            GameObject spell = Instantiate(spell1, transform.position, Quaternion.identity);
            spell.GetComponent<Spell1Physics>().Spawn();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            MeleeAttack();
        }
    }
}
