using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerberus : Boss {
    public static float maxHealth = 1000f;
    private float health;
    public float walkSpeed = 5f;
    public float walkTime = 1f;
    public float walkCooldown = .5f;
    public float runSpeed = 7f;
    public float runTime = 3f;
    public float runCooldown = 1f;

    public float touchCooldown = .5f;
    public int touchDamage = 50;
    [SerializeField] private GameObject fireballPrefab;
    public int fireballDamage = 30;
    public float fireballSpeed = 10f;
    public float fireballCooldown = 1f; // Cooldown time in seconds
    public float fireballSpread = 30f;
    private float nextAttackTime; // When the next attack can happen

    private bool acting = false;
    private bool hitWall = false;

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

        StartCoroutine(Act());

    }

    public override void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0) Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if the enemy collided with the player
        if (other.gameObject.CompareTag("playerBody") )
        {
            // get the player's script component and call TakeDamage
            playerInfo.TakeDamage(touchDamage);
        } else if (other.gameObject.CompareTag("Wall"))
        {
            hitWall = true;
        }
    }

    private Vector3 CheckPlayerDirection()
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

        return playerDirection;
    }

    private void Decide(int actions)
    {
        int r = Random.Range(0,actions);

        switch(r)
        {
            case 0:
            Move(walkSpeed, walkTime, walkCooldown);
            break;
            case 1:
            Jump();
            break;
            case 2:
            ChargeFire();
            break;
        }

        Debug.Log(r);
    }

    private void ChargeFire()
    {
        CheckPlayerDirection();
        anim.SetBool("Fire", true);
    }

    private void Move(float speed, float time, float cooldown)
    {
        // Possible directions to choose from
        List<PlayerInfo.Direction> directions = new List<PlayerInfo.Direction>((PlayerInfo.Direction[])System.Enum.GetValues(typeof(PlayerInfo.Direction)));

        // Determine the direction vector based on the direction variable
        Vector2 moveDirection = Vector2.zero;

        float wallCheckDistance = 10;


        // Keep trying random directions until a valid one without a barrier is found
        while (directions.Count > 0)
        {
            // Pick a random direction
            int randomIndex = Random.Range(0, directions.Count);
            direction = directions[randomIndex];

            // Translate the enum direction into a Vector2
            switch (direction)
            {
                case PlayerInfo.Direction.Up:
                    moveDirection = Vector2.up;
                    break;
                case PlayerInfo.Direction.Down:
                    moveDirection = Vector2.down;
                    break;
                case PlayerInfo.Direction.Left:
                    moveDirection = Vector2.left;
                    break;
                case PlayerInfo.Direction.Right:
                    moveDirection = Vector2.right;
                    break;
            }

            // Get the layer number for "Wall"
            int layerNumber = LayerMask.NameToLayer("Walls");

            // Create a layer mask that includes only the "Wall" layer
            int layerMask = 1 << layerNumber;

            // Raycast in the move direction to check for barriers
            RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, wallCheckDistance, layerMask);

            Debug.DrawRay(transform.position, moveDirection * wallCheckDistance, Color.red, 2f); // Duration of 1 second
            
            if (hit.collider != null)
            {
                Debug.Log("Raycast hit: " + hit.collider.name);
                directions.RemoveAt(randomIndex);
                // Barrier detected, don't move
                
            }
            else
            {
                // Remove the direction that led to a barrier
                Debug.Log("Raycast missed.");
                break;
                
            }
        }

        // Start the movement coroutine
        StartCoroutine(MoveCoroutine(moveDirection, speed, time, cooldown));
    }

    private IEnumerator MoveCoroutine(Vector2 moveDirection, float speed, float time, float cooldown)
    {
        float startTime = Time.time;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = transform.position + (Vector3)moveDirection * speed;

        anim.SetInteger("Direction", (int)direction);
        anim.SetBool("Move", true);

        while (Time.time < startTime + time && !hitWall)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, (Time.time - startTime) / time);
            yield return null;
        }

        hitWall = false;

        anim.SetBool("Move", false);
        anim.speed = 1f;
        nextAttackTime = cooldown;
        acting = false;
    }

    private void Jump()
    {
        anim.SetTrigger("Jump");
    }

    private void Fire()
    {
        MakeFireballs();
        nextAttackTime = fireballCooldown; // Reset the attack timer
        anim.SetBool("Fire", false);
        acting = false;
    }

    private void MakeFireballs()
    {
        Vector3 shootDirection = (player.transform.position - transform.position).normalized;

        // Create the central fireball
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        fireball.GetComponent<CerbBall>().Initialize(fireballDamage, fireballSpeed, shootDirection);

        // Create the left fireball
        Vector3 leftDirection = Quaternion.Euler(0, 0, fireballSpread) * shootDirection; // Rotate shootDirection by 30 degrees to the left
        GameObject leftFireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        leftFireball.GetComponent<CerbBall>().Initialize(fireballDamage, fireballSpeed, leftDirection);

        // Create the right fireball
        Vector3 rightDirection = Quaternion.Euler(0, 0, -fireballSpread) * shootDirection; // Rotate shootDirection by 30 degrees to the right
        GameObject rightFireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        rightFireball.GetComponent<CerbBall>().Initialize(fireballDamage, fireballSpeed, rightDirection);
    }

    private void Rush()
    {
        anim.ResetTrigger("Jump");
        
        Vector3 playerDirection = CheckPlayerDirection();
        anim.speed = 2f;
        StartCoroutine(MoveCoroutine(playerDirection, runSpeed, runTime, runCooldown));
    }

    private IEnumerator Act()
    {
        int actions = 3;

        while (true)
        {
            Decide(actions);
            acting = true;

            while (acting)
            {

                yield return new WaitForSeconds(.5f);
            }

            yield return new WaitForSeconds(nextAttackTime);
        }
    }
}