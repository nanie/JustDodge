using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameVariables", menuName = "ScriptableObjects/Game Variables", order = 1)]
public class ScriptableGameVariables : ScriptableObject
{
    [Tooltip("Is the variables in use")]
    public bool inUse;
    [Header("Player")]
    [Tooltip("Player movement speed")]
    public float playerSpeed = 5;
    [Tooltip("How smooth is the movement of camera")]
    public float cameraSmoothFactor = 0.3f;
    [Tooltip("Player health points")]
    public int playerHealthPoints = 3;
    [Header("Enemy")]
    [Tooltip("Prefabs of enemies and theys chances of spawning")]
    public EnemySpawnConfiguration[] enemySpawnConfiguration;
    [Tooltip("Start enemy spawn rate")]
    public float EnemySpawnRate = 2;
    [Tooltip("Start enemy spawn rate increase over time")]
    public float EnemySpawnRateOverTime = 0.1f;
    [Tooltip("Minimal enemy spawn rate")]
    public float MinimalEnemySpawnRateOverTime = 0.3f;
    [Tooltip("Enemy movement speed")]
    public float enemySpeed = 1;
    [Tooltip("Ping pong hits before destroy")]
    public int EnemyPingpongHitCount = 3;
    [Tooltip("Follower Enemy change direction time")]
    public float enemyChangeTime = 2;
}

[System.Serializable]
public class EnemySpawnConfiguration
{
    public GameObject prefab;
    public int chance;
}