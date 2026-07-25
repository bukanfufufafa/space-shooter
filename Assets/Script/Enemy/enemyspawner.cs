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

    public bool defeated { get; private set; }

    public void BeginSpawn()
    {
        defeated = false;
        currentSpawned = 0;
        enemyReference.Clear();

        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (currentSpawned < totalEnemy)
        {
            GameObject enemy = Instantiate(
                enemyPrefab,
                transform.position,
                Quaternion.identity);

            enemyReference.Add(enemy);

            currentSpawned++;

            yield return new WaitForSeconds(spawnDelay);
        }

        StartCoroutine(CheckDefeated());
    }

    IEnumerator CheckDefeated()
    {
        while (true)
        {
            enemyReference.RemoveAll(enemy => enemy == null);

            if (enemyReference.Count == 0)
            {
                defeated = true;
                yield break;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}