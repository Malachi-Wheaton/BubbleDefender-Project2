using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] pathPoints;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 2f, 2f);
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, pathPoints[0].position, Quaternion.identity);
        enemy.GetComponent<Enemy>().pathPoints = pathPoints;
    }
}
