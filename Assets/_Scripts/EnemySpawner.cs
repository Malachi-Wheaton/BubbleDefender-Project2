using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // Added missing import for UnityEvent

public class EnemySpawner : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;
    [SerializeField] private int maxWaves = 5; // Add max waves limit

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent(); // ✅ Added missing semicolon and initialized UnityEvent

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartCoroutine(StartWave()); // Fixed StartCoroutine call
    }

    private void Update()
    {
        if (!isSpawning || currentWave > maxWaves) return; // Stop if max waves reached

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    private IEnumerator StartWave()
    {
        if (currentWave > maxWaves) yield break; // Exit coroutine if max waves reached

        yield return new WaitForSeconds(timeBetweenWaves); // Fixed WaitForSeconds typo

        isSpawning = true;
        enemiesLeftToSpawn += EnemiesPerWave();
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;

        if (currentWave > maxWaves) return; // Stop spawning if max waves reached
        StartCoroutine(StartWave()); // Fixed StartCoroutine call
    }

    private void SpawnEnemy()
    {
        if (enemyPrefabs.Length < 2) return; // Ensure there are at least two types of enemies

        // Randomly choose between the first two enemies
        GameObject prefabToSpawn = enemyPrefabs[Random.Range(0, 2)];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
}





