using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnpoints; // Spawnpoints

    public List<Enemy> enemies = new List<Enemy>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public int waveNum = 0;

    public int currWave;
    private int waveVal;

    //public Vector2 spawnVal;

    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    public bool spawnerOn;
    public float delay;

    public PlayerHealth pHealth;

    void Start()
    {
        spawnerOn = true;
        GenerateWave();
    }

    private void Update()
    {
        if (spawnerOn && waveNum == 0 && delay == 3)
        {
            GenerateEnemies();
        }
        else
        {
            delay += Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (pHealth.currentHealth > 0 && spawnerOn)
        {
            if (spawnTimer <= 0)
            {
                if (enemiesToSpawn.Count > 0 && delay >= 3)
                {
                    int randSpawn = Random.Range(0, spawnpoints.Length); // Randomize the spawnpoints
                    Instantiate(enemiesToSpawn[0], spawnpoints[randSpawn].position, Quaternion.identity);
                    enemiesToSpawn.RemoveAt(0);
                    spawnTimer = spawnInterval;
                }
                else if (enemiesToSpawn.Count <= 0)
                {
                    Debug.Log("Generating wave");
                    waveTimer = 0;
                    currWave += 1;
                    waveDuration += 5;
                    delay = 0;
                    GenerateWave();
                }
            }
            else
            {
                spawnTimer -= Time.fixedDeltaTime;
                waveTimer -= Time.fixedDeltaTime;
            }
        }
        else if (pHealth.currentHealth <= 0 && spawnerOn)
        {
            spawnerOn = false;
        }
    }

    public void GenerateWave()
    {
        AudioManager.Instance.Play("Wave");
        spawnerOn = true;

        waveNum += 1;

        waveVal = currWave * 10;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration;
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveVal > 0)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveVal - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveVal -= randEnemyCost;
            }
            else if (waveVal <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    [System.Serializable]
    public class Enemy
    {
        public GameObject enemyPrefab;
        public int cost;
    }
}