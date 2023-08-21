using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public Direction direction = Direction.Down;

    private Animator anim;
    [SerializeField] private float maxHealth = 100f;
    private HealthBar healthBar;
    private float currentHealth;  // player's health
    private bool isShieldActive = false; // Add this variable

    private void Start()
    {
        currentHealth = maxHealth;

        TryGetComponent(out anim);

        healthBar = GameObject.FindGameObjectWithTag("Canvas").transform.GetComponentInChildren<HealthBar>();
        healthBar.SetHealth(currentHealth/maxHealth);
        
    }
    private void Update() {
        if (Input.GetKey(KeyCode.W))
        {
            direction = Direction.Up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = Direction.Down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction = Direction.Left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = Direction.Right;
        }

        anim.SetInteger("Direction", (int)direction);
    }

    public void TakeDamage(float damage)
    {
        if (!isShieldActive) // Check if the shield is not active
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth/maxHealth);

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }   

    // Method to set the shield's active status
    public void SetShieldActive(bool active)
    {
        isShieldActive = active;
    }

    // Method to check if the shield is active
    public bool IsShieldActive()
    {
        return isShieldActive;
    }

    public void Heal(float heal)
    {
        if (heal + currentHealth < maxHealth)
            currentHealth += heal;
        else 
            currentHealth = maxHealth;

        healthBar.SetHealth(currentHealth/maxHealth);
    }
}
