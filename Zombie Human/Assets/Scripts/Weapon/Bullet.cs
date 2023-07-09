using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem blood;

    void Awake()
    {
        Destroy(gameObject, 4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Zombie"))
        {
            CreateBlood();
            FindObjectOfType<AudioManager>().Play("ZombieHurt");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else if(collision.gameObject.CompareTag("Player"))
        {
            CreateBlood();
            Destroy(gameObject);
        }
    }

    void CreateBlood()
    {
        blood.Play();
    }
}
