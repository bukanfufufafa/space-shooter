using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveTrigger : MonoBehaviour
{
    [Header("Wave")]
    [SerializeField] private List<EnemySpawner> spawnerWave1 = new();
    [SerializeField] private List<EnemySpawner> spawnerWave2 = new();

    //[SerializeField] private StageManager stageManager;

    private bool wave1Finished;
    private bool wave2Finished;

    private void Start()
    {
        wave1Finished = false;
        wave2Finished = false;

        // Wave 2 disembunyikan
        foreach (EnemySpawner spawner in spawnerWave2)
        {
            spawner.gameObject.SetActive(false);
        }

        // Reset Wave 1
        foreach (EnemySpawner spawner in spawnerWave1)
        {
            spawner.gameObject.SetActive(true);
            spawner.ResetGroup();
        }
    }

    private void Update()
    {
        // ======================
        // Wave 1
        // ======================

        if (!wave1Finished)
        {
            if (spawnerWave1.All(x => x.Defeated))
            {
                wave1Finished = true;

                Debug.Log("Wave 1 Selesai");

                //stageManager.OnStageCleared();

                foreach (EnemySpawner spawner in spawnerWave2)
                {
                    spawner.gameObject.SetActive(true);
                    spawner.ResetGroup();
                }
            }
        }

        // ======================
        // Wave 2
        // ======================

        if (!wave2Finished)
        {
            if (spawnerWave2.All(x => x.Defeated))
            {
                wave2Finished = true;

                Debug.Log("Wave 2 Selesai");

                //stageManager.OnStageCleared();
            }
        }
    }

    public void StartWave2()
    {
        foreach (EnemySpawner spawner in spawnerWave2)
        {
            spawner.gameObject.SetActive(true);
            spawner.ResetGroup();
        }
    }
}