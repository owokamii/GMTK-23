using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public ParticleSystem blood;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            CreateBlood();
            FindObjectOfType<AudioManager>().Play("ZombieHurt");
            Destroy(collision.gameObject);
        }
    }

    void CreateBlood()
    {
        blood.Play();
    }
}
