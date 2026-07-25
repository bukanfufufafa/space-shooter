using UnityEngine;

/// <summary>
/// Stub minimal. Kalau kalian sudah punya script HP player sendiri,
/// tinggal tambahin method AddExtraLives() di sana dan hapus file ini.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    public int lives = 3;

    public void AddExtraLives(int amount)
    {
        lives += amount;
        Debug.Log($"Nyawa nambah! Total sekarang: {lives}");
    }
}
