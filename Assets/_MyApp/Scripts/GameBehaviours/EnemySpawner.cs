using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //The chances are calculated relative to the sum of all chances
    SpawnConfiguration[] enemySpawnConfig;
    //Timer variable to control spawn
    private float timer;
    //Control the current spawn interval
    private float spawnTimer;
    //Sum of all chances
    int totalChance;
    //Reference to player event manager 
    PlayerEventManager playerEvent;

    void Start()
    {
        spawnTimer = GlobalGameVariables.Instance.variables.EnemySpawnInterval;
        enemySpawnConfig = GlobalGameVariables.Instance.variables.enemySpawnConfiguration;
        timer = spawnTimer;
        totalChance = enemySpawnConfig.Sum(q => q.chance);
        playerEvent = FindObjectOfType<PlayerEventManager>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //Add 1 point to the player score for every spawned enemy
            playerEvent.PlayerScore(1);

            //Check if the spawn interval isn't already less than the minimal and if it isn't decreases interval
            if (spawnTimer > GlobalGameVariables.Instance.variables.MinimalEnemySpawnIntervalOverTime)
                spawnTimer -= GlobalGameVariables.Instance.variables.EnemySpawnIntervalOverTime;
            timer = spawnTimer;

            //create a random number
            var rand = Random.Range(0, totalChance + 1);
            GameObject objectToInstantiate = enemySpawnConfig[0].prefab;
            //find the enemy it should spawn respecting the spawn configuration odds
            foreach (var item in enemySpawnConfig)
            {
                objectToInstantiate = item.prefab;
                rand -= item.chance;
                if (rand <= 0)
                    break;
            }
            //Find a random spawn point between spawn children and instantiate a enemy at it's position
            rand = Random.Range(0, transform.childCount);
            Instantiate(objectToInstantiate, transform.GetChild(rand).position, Quaternion.identity);
        }
    }
}

