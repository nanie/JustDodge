using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    //The chances are calculated relative to the sum of all chances
    SpawnConfiguration[] itemSpawnConfig;
    //Timer variable to control spawn
    private float timer;
    //Control the current spawn interval
    private float spawnTimer;
    //Sum of all chances
    int totalChance;
    //Reference to player event manager 
    PlayerEventManager playerEvent;
    //Itens already spawned
    GameObject[] spawnedItems;

    void Start()
    {
        spawnedItems = new GameObject[transform.childCount];
        spawnTimer = GlobalGameVariables.Instance.variables.ItemSpawnInterval;
        itemSpawnConfig = GlobalGameVariables.Instance.variables.itemSpawnConfiguration;
        timer = spawnTimer;
        totalChance = itemSpawnConfig.Sum(q => q.chance);
        playerEvent = FindObjectOfType<PlayerEventManager>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //Reset timer to spawn
            timer = spawnTimer;
            //create a random number
            var rand = Random.Range(0, totalChance + 1);
            GameObject objectToInstantiate = itemSpawnConfig[0].prefab;
            //find the item it should spawn respecting the spawn configuration odds
            foreach (var item in itemSpawnConfig)
            {
                objectToInstantiate = item.prefab;
                rand -= item.chance;
                if (rand <= 0)
                    break;
            }
            //Find a random spawn point between spawn children and find the next empty slot           
            rand = Random.Range(0, transform.childCount);
            int index = rand;
            for (int i = rand; i < spawnedItems.Length + rand; i++)
            {
                if (spawnedItems[i % spawnedItems.Length] == null)
                {
                    index = i % spawnedItems.Length;
                    break;
                }
            }
            //If there isn't a empty slot it doesn't spawn
            if (spawnedItems[index] == null)
                spawnedItems[index] = Instantiate(objectToInstantiate, transform.GetChild(index).position, Quaternion.identity);
            else
                print("full");
        }
    }
}
