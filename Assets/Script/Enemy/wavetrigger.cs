using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveTrigger : MonoBehaviour
{
    [Header("Wave")]
    [SerializeField] private List<EnemySpawner> spawnerWave1 = new();
    [SerializeField] private List<EnemySpawner> spawnerWave2 = new();

    //[SerializeField] private StageManager stageManager;

    [SerializeField]private bool wave1Finished = false;
    [SerializeField]private bool wave2Finished = false;

    private void Start()
    {
        foreach (EnemySpawner spawner in spawnerWave2)
        {
            spawner.gameObject.SetActive(false);
        }

        foreach (EnemySpawner spawner in spawnerWave1)
        {
            spawner.gameObject.SetActive(true);
            spawner.BeginSpawn();
        }
    }

    private void Update()
    {
        if (!wave1Finished)
        {
            if (spawnerWave1.All(x => x.defeated))
            {
                wave1Finished = true;

                //stageManager.OnStageCleared();

                foreach (EnemySpawner spawner in spawnerWave2)
                {
                    spawner.gameObject.SetActive(true);
                    spawner.BeginSpawn();
                }
            }
        }

        if (!wave2Finished)
        {
            if (spawnerWave2.All(x => x.defeated))
            {
                wave2Finished = true;

                //stageManager.OnStageCleared();
            }
        }
    }

    public void StartWave2()
    {
        foreach (EnemySpawner spawner in spawnerWave2)
        {
            spawner.gameObject.SetActive(true);
            spawner.BeginSpawn();
        }
    }
}