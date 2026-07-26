using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Reference")]
    [SerializeField] private List<GameObject> enemyReference = new();

    public bool Defeated { get; private set; }

    private void Awake()
    {
        // Jika list kosong, otomatis ambil semua child
        if (enemyReference.Count == 0)
        {
            foreach (Transform child in transform)
            {
                enemyReference.Add(child.gameObject);
            }
        }

        Defeated = false;
    }

    private void Update()
    {
        if (Defeated)
            return;

        enemyReference.RemoveAll(enemy =>
            enemy == null || !enemy.activeInHierarchy);

        if (enemyReference.Count == 0)
        {
            Defeated = true;
            Debug.Log($"{gameObject.name} selesai.");
        }
    }

    public void ResetGroup()
    {
        Defeated = false;

        enemyReference.Clear();

        foreach (Transform child in transform)
        {
            enemyReference.Add(child.gameObject);
        }
    }
}