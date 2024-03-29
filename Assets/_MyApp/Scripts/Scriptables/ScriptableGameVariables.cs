﻿using System.Collections;
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
    [Tooltip("Player maximum points")]
    public int playerMaxHealthPoints = 3;
    [Header("Enemy")]
    [Tooltip("Prefabs of enemies and theys chances of spawning")]
    public SpawnConfiguration[] enemySpawnConfiguration;
    [Tooltip("Start enemy spawn interval")]
    public float EnemySpawnInterval = 2;
    [Tooltip("The amount of time is decreased of the enemy's spawn interval over time")]
    public float EnemySpawnIntervalOverTime = 0.1f;
    [Tooltip("Minimal enemy spawn interval")]
    public float MinimalEnemySpawnIntervalOverTime = 0.3f;
    [Tooltip("Enemy movement speed")]
    public float enemySpeed = 1;
    [Tooltip("Ping pong hits before destroy")]
    public int EnemyPingpongHitCount = 3;
    [Tooltip("Follower Enemy change direction time")]
    public float enemyChangeTime = 2;
    [Header("Items")]
    [Tooltip("Item spawn interval")]
    public float ItemSpawnInterval = 4;
    [Tooltip("Prefabs of enemies and theys chances of spawning")]
    public SpawnConfiguration[] itemSpawnConfiguration;
}

[System.Serializable]
public class SpawnConfiguration
{
    public GameObject prefab;
    public int chance;
}