using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public ParticleSystem blood;
    
    //public PlayerHealth health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            CreateBlood();
            AudioManager.Instance.Play("ZombieHurt");
            Destroy(collision.gameObject);
        }
/*        else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("fk u");
            CreateBlood();
            FindObjectOfType<AudioManager>().Play("ZombieHurt");
            health.TakeDamage(10);
        }
*/    }

    void CreateBlood()
    {
        blood.Play();
    }
}
