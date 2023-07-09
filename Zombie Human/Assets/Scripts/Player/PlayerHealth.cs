using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public ParticleSystem blood;

    public int sceneID;

    public float maxHealth = 100f;
    public float currentHealth;

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
        }
    }

/*    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("IDK");
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Knife"))
        {
            Debug.Log("FK U 2");
            TakeDamage(10);
            CreateBlood();
            FindObjectOfType<AudioManager>().Play("ZombieHurt");
        }
    }
*/
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Heal(float damage)
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
