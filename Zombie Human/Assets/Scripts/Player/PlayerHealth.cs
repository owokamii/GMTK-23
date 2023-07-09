using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public ParticleSystem blood;

    public float maxHealth = 100f;
    public float currentHealth;

    public HealthBar healthBar;

    private bool isInDamageCD;

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
            CreateBlood();
            FindObjectOfType<AudioManager>().Play("ZombieHurt");
        }
        else if (collision.gameObject.CompareTag("Meds"))
        {
            Heal(20);
            FindObjectOfType<AudioManager>().Play("Pickup");
            Destroy(collision.gameObject);
            Invoke("TakeDamage", 2);
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

    void CreateBlood()
    {
        blood.Play();
    }
}
