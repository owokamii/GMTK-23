using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public ParticleSystem blood;

    public int sceneID;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(sceneID);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
            CreateBlood();

            AudioManager.Instance.Play("ZombieHurt");
        }
        else if (collision.gameObject.CompareTag("Knife"))
        {
            TakeDamage(15);
            CreateBlood();

            AudioManager.Instance.Play("ZombieHurt");
        }
        else if (collision.gameObject.CompareTag("Meds"))
        {
            Heal(20);
            AudioManager.Instance.Play("Pickup");
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Heal(int damage)
    {
        if(currentHealth < maxHealth) 
        { 
            currentHealth += damage;
            healthBar.SetHealth(currentHealth);
        }
        
    }

    void CreateBlood()
    {
        blood.Play();
    }
}
