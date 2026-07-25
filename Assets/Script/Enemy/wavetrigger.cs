using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class wavetrigger : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private List<EnemySpawner> spawnerWave1 = new List<EnemySpawner>();
    [SerializeField] private List<EnemySpawner> spawnerWave2 = new List<EnemySpawner>();

    private int paternDefeated;
    void Start()
    {
        
        foreach (var item in spawnerWave2)
        {
            item.gameObject.SetActive(false);
        }

        foreach (var item in spawnerWave1)
        {
            item.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (EnemySpawner spawner in spawnerWave1)
        {
            if (spawner.defeated = true)
            {
                paternDefeated++;
            }
        }

        foreach (EnemySpawner spawner in spawnerWave2)
        {
            if (spawner.defeated = true)
            {
                paternDefeated++;
            }
        }
    }
}
