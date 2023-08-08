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

    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private HealthBar healthBar;
    private float currentHealth;  // player's health


    private void Start()
    {
        currentHealth = maxHealth;
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
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth/maxHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
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
