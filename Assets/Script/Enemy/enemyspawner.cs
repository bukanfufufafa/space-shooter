using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private GameObject enemyPrefab;

    [Header("Spawn Setting")]
    [SerializeField] private int totalEnemy = 10;
    [SerializeField] private float spawnDelay = 1f;

    private int currentSpawned = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (currentSpawned < totalEnemy)
        {
            Instantiate(
                enemyPrefab,
                transform.position,
                Quaternion.identity
            );

            currentSpawned++;

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}