using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Enemies;
    public List<GameObject> SpawnPoints;

    public float Money = 100;
    public static GameManager theInstance;
    void Start()
    {
        if (theInstance == null)
            theInstance = this;

        Money = 1000;
    }
    void Update()
    {
        WaveProcessing();
    }

    void WaveProcessing()
    {
        //looking for enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            SpawnEnemies();
        }

    }

     void SpawnEnemies()
    {
        for (int i = 0; i < SpawnPoints.Count; i++)
        {
            Vector2 spawnPosition = SpawnPoints[i].transform.position;
            Instantiate(Enemies[UnityEngine.Random.Range(0, Enemies.Count)], spawnPosition, Quaternion.identity);
        }
    }
}
