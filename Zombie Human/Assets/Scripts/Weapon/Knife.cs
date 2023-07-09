using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public ParticleSystem blood;
    
    public PlayerHealth health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            CreateBlood();
            FindObjectOfType<AudioManager>().Play("ZombieHurt");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("fk u");
            health.TakeDamage(10);
            CreateBlood();
            FindObjectOfType<AudioManager>().Play("ZombieHurt");
        }
    }

    void CreateBlood()
    {
        blood.Play();
    }
}
