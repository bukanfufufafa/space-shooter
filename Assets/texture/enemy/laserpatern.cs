using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserController : MonoBehaviour
{
    [Header("Boss")]
    [SerializeField] private enemystat bossStat;

    [Header("Health Trigger")]
    [SerializeField] private float activateHealth = 50f;

    [Header("Laser Prefab")]
    [SerializeField] private GameObject verticalLaserPrefab;
    [SerializeField] private GameObject horizontalLaserPrefab;

    [Header("Spawn Point")]
    [SerializeField] private List<Transform> verticalSpawnPoint = new();
    [SerializeField] private List<Transform> horizontalSpawnPoint = new();

    [Header("Laser Setting")]
    [SerializeField] private float patternInterval = 5f;
    [SerializeField] private float laserDuration = 2f;

    private bool laserActivated = false;

    private void Update()
    {
        if (!laserActivated && bossStat.health <= activateHealth)
        {
            laserActivated = true;
            StartCoroutine(LaserRoutine());
        }
    }

    IEnumerator LaserRoutine()
    {
        while (bossStat != null && bossStat.health > 0)
        {
            int randomPattern = Random.Range(0, 2);

            switch (randomPattern)
            {
                case 0:
                    SpawnVerticalLaser();
                    break;

                case 1:
                    SpawnHorizontalLaser();
                    break;
            }

            yield return new WaitForSeconds(patternInterval);
        }
    }

    void SpawnVerticalLaser()
    {
        if (verticalSpawnPoint.Count == 0) return;

        int index = Random.Range(0, verticalSpawnPoint.Count);

        GameObject laser = Instantiate(
            verticalLaserPrefab,
            verticalSpawnPoint[index].position,
            Quaternion.identity);

        Destroy(laser, laserDuration);
    }

    void SpawnHorizontalLaser()
    {
        if (horizontalSpawnPoint.Count == 0) return;

        int index = Random.Range(0, horizontalSpawnPoint.Count);

        GameObject laser = Instantiate(
            horizontalLaserPrefab,
            horizontalSpawnPoint[index].position,
            Quaternion.identity);

        Destroy(laser, laserDuration);
    }
}