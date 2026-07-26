using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class wavetrigger : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> spawnerWave1 = new List<EnemySpawner>();
    [SerializeField] private List<EnemySpawner> spawnerWave2 = new List<EnemySpawner>();

    [Header("Referensi")]
    [SerializeField] private StageManager stageManager;

    private bool wave2Started = false;
    private bool waveAllDone = false;

    private void Start()
    {
        foreach (var item in spawnerWave2)
            item.gameObject.SetActive(false);

        foreach (var item in spawnerWave1)
            item.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (waveAllDone) return; // udah kelar semua, gak perlu ngecek lagi

        if (!wave2Started)
        {
            // Cek pakai == (perbandingan), bukan = (assignment)
            bool wave1Done = spawnerWave1.All(s => s.defeated == true);

            if (wave1Done)
            {
                StartWave2();
            }
        }
        else
        {
            bool wave2Done = spawnerWave2.All(s => s.defeated == true);

            if (wave2Done)
            {
                waveAllDone = true;

                if (stageManager != null)
                    stageManager.OnStageCleared();

                Debug.Log("Semua wave di stage ini selesai!");
            }
        }
    }

    private void StartWave2()
    {
        wave2Started = true;

        foreach (var item in spawnerWave2)
            item.gameObject.SetActive(true);

        Debug.Log("Wave 1 selesai, Wave 2 dimulai!");
    }
}
