using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private GameObject enemyPrefab;

    [Header("Spawn Setting")]
    [SerializeField] private int totalEnemy = 10;
    [SerializeField] private float spawnDelay = 1f;

    [SerializeField] private List<GameObject> enemyReference = new();

    private int currentSpawned = 0;
    public bool defeated = false;
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (currentSpawned < totalEnemy)
        {
            GameObject enemy = Instantiate(
                enemyPrefab,
                transform.position,
                Quaternion.identity
            );

            enemyReference.Add(enemy);

            currentSpawned++;

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}