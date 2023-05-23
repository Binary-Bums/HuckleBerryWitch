using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private HealthBar healthBar;
    private float currentHealth;  // player's health


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth/maxHealth);
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
