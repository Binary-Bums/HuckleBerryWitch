using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerInfo playerInfo;

    [SerializeField] private List<GameObject> spells;
    private int activeSpell = 0;
    [SerializeField] private float damageAmount = 30f;
    [SerializeField] private float attackRadius = 1.5f;
    [SerializeField] public float attackCooldown = 1f;
    private bool canAttack = true;

    private void Start() {
        playerInfo = GetComponent<PlayerInfo>();
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

    private void UseSpell()
    {
        // Check if the player can attack
        if (!canAttack)
            return;

        GameObject spell = Instantiate(spells[activeSpell], transform.position, Quaternion.identity);
        spell.GetComponent<Spell>().Spawn(playerInfo);

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
            UseSpell();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            MeleeAttack();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (activeSpell + 1 >= spells.Count) activeSpell = 0;

            else activeSpell++;
        }
    }
}
