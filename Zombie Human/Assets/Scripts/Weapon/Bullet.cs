using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject, 4);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Zombie"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Human"))
        {
            Destroy(gameObject);
        }
    }
}
