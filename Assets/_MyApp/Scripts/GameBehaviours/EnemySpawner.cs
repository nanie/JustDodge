using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //The chances are calculated relative to the sum of all chances
    EnemySpawnConfiguration[] enemyChances;
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
        spawnTimer = GlobalGameVariables.Instance.variables.EnemySpawnRate;
        enemyChances = GlobalGameVariables.Instance.variables.enemySpawnConfiguration;
        timer = spawnTimer;
        totalChance = enemyChances.Sum(q => q.chance);
        playerEvent = FindObjectOfType<PlayerEventManager>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            playerEvent.PlayerScore(1);

            if (spawnTimer > GlobalGameVariables.Instance.variables.MinimalEnemySpawnRateOverTime)
                spawnTimer -= GlobalGameVariables.Instance.variables.EnemySpawnRateOverTime;
            timer = spawnTimer;

            var rand = Random.Range(0, totalChance + 1);
            GameObject objectToInstantiate = enemyChances[0].prefab;
            foreach (var item in enemyChances)
            {
                objectToInstantiate = item.prefab;
                rand -= item.chance;
                if (rand <= 0)
                    break;
            }

            rand = Random.Range(0, transform.childCount);

            Instantiate(objectToInstantiate, transform.GetChild(rand).position, Quaternion.identity);
        }
    }
}

