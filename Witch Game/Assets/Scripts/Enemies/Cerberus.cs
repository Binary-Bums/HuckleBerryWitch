using System;
using UnityEngine;

public class Cerberus : MonoBehaviour {
    public static float maxHealth;
    private float health;
    public float walkSpeed;
    public float runSpeed;

    public float touchCooldown;
    public int touchDamage;
    [SerializeField] private GameObject fireballPrefab;
    public float fireballDamage = 40f;
    public float fireballSpeed = 10f;
    public float fireballCooldown = 1f; // Cooldown time in seconds
    private float nextAttackTime; // When the next attack can happen

    private State state = State.Neutral;
    private PlayerInfo.Direction direction = PlayerInfo.Direction.Down;

    private GameObject player;
    private PlayerInfo playerInfo;
    private Animator anim;


    private enum State
    {
        Neutral,
        Moving,
        Attacking,
        Damaged,
    }

    private void Start() {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        playerInfo = player.GetComponent<PlayerInfo>();
        nextAttackTime = Time.time + fireballCooldown; // Initialize the next attack time
        TryGetComponent(out anim);

    }

    private void Update() {

        if (Time.time >= nextAttackTime) // Check if it's time to attack
        {
            CheckDirection();
            Decide();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if the enemy collided with the player
        if (other.gameObject.CompareTag("playerBody") )
        {
            // get the player's script component and call TakeDamage
            playerInfo.TakeDamage(touchDamage);
        }
    }

    private void CheckDirection()
    {
        Vector3 playerDirection = (player.transform.position - transform.position).normalized;

        if(Mathf.Abs(playerDirection.x) > Mathf.Abs(playerDirection.y))
        {
            // Horizontal movement is greater
            if(playerDirection.x > 0)
            {
                direction = PlayerInfo.Direction.Right;
            }
            else
            {
                direction = PlayerInfo.Direction.Left;
            }
        }
        else
        {
            // Vertical movement is greater
            if(playerDirection.y > 0)
            {
                direction = PlayerInfo.Direction.Up;
            }
            else
            {
                direction = PlayerInfo.Direction.Down;
            }
        }

        anim.SetInteger("Direction", (int)direction);
    }

    private void Decide()
    {
        
    }

    private void ChargeFire()
    {
        anim.SetBool("Fire", true);
    }

    private void Move()
    {
        anim.SetBool("Move", true);
    }

    private void Fire()
    {
        Vector3 shootDirection = (player.transform.position - transform.position).normalized;
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        fireball.GetComponent<CerbBall>().Initialize(fireballDamage, fireballSpeed, shootDirection);
        nextAttackTime = Time.time + fireballCooldown; // Reset the attack timer
        anim.SetBool("Fire", false);
    }

    private void Rush()
    {
        
    }
}