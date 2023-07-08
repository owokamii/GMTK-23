using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnpoints; // Spawnpoints
    public GameObject[] enemies; // Customer list

    public Vector2 spawnVal;

    public bool stop;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waitSpawner()
    {
        //yield return new WaitForSeconds(10);

        while (!stop)
        {
            int randEnemy = Random.Range(0, enemies.Length); // Randomize the zombie type
            int randSpawn = Random.Range(0, spawnpoints.Length); // Randomize the spawnpoints

            Instantiate(enemies[randEnemy], spawnpoints[randSpawn].position, Quaternion.identity);
            
            //Instantiate(cusPrefabs[randCus], spawnpoint.position, Quaternion.identity);
            //Instantiate(cusPrefabs[randCus], spawnpoint.position + new Vector3(1f, 0f, 0f), Quaternion.identity);

            yield return new WaitForSeconds(timer);
        }
    }

}
