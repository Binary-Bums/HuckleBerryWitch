using System.Collections;
using UnityEngine;

public class Cerberus : MonoBehaviour {
    public static float maxHealth = 100f;
    private float health;
    public float walkSpeed = 5f;
    public float walkTime = 1f;
    public float walkCooldown = .5f;
    public float runSpeed = 7f;
    public float runTime = 3f;
    public float runCooldown = 1f;

    public float touchCooldown = .5f;
    public int touchDamage = 20;
    [SerializeField] private GameObject fireballPrefab;
    public int fireballDamage = 40;
    public float fireballSpeed = 10f;
    public float fireballCooldown = 1f; // Cooldown time in seconds
    private float nextAttackTime; // When the next attack can happen

    private bool acting = false;

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

    private void Update() {

        
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
        CheckDirection();
        anim.SetBool("Fire", true);
    }

    private void Move(float speed, float time, float cooldown)
    {
        CheckDirection();
        // Determine the direction vector based on the direction variable
        Vector2 moveDirection = Vector2.zero;
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

        // Raycast in the move direction to check for barriers
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, 1f /* or desired distance */);
        if (hit.collider != null && hit.collider.tag == "Barrier")
        {
            // Barrier detected, don't move
            return;
        }

        // Start the movement coroutine
        StartCoroutine(MoveCoroutine(moveDirection, speed, time, cooldown));
    }

    private IEnumerator MoveCoroutine(Vector2 moveDirection, float speed, float time, float cooldown)
    {
        float startTime = Time.time;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = transform.position + (Vector3)moveDirection * speed;

        anim.SetBool("Move", true);

        while (Time.time < startTime + time)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, (Time.time - startTime) / time);
            yield return null;
        }

        anim.SetBool("Move", false);
        nextAttackTime = cooldown;
        acting = false;
    }

    private void Jump()
    {
        anim.SetTrigger("Jump");
    }

    private void Fire()
    {
        Vector3 shootDirection = (player.transform.position - transform.position).normalized;
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        fireball.GetComponent<CerbBall>().Initialize(fireballDamage, fireballSpeed, shootDirection);
        nextAttackTime = fireballCooldown; // Reset the attack timer
        anim.SetBool("Fire", false);
        acting = false;
    }

    private void Rush()
    {
        anim.ResetTrigger("Jump");
        Move(runSpeed, runTime, runCooldown);
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