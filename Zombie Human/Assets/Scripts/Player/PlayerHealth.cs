using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Knife"))
        {
            TakeDamage(10);
            FindObjectOfType<AudioManager>().Play("ZombieHurt");
        }
        else if (collision.gameObject.CompareTag("Meds"))
        {
            Heal(10);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Heal(float damage)
    {
        currentHealth += damage;
        healthBar.SetHealth(currentHealth);
    }
}
