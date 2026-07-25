using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3;

    public void AddExtraLives(int amount)
    {
        lives += amount;
        Debug.Log($"Nyawa nambah! Total sekarang: {lives}");
    }

    public void TakeDamage(int amount)
    {
        lives -= amount;

        if (PlayerPowerController.Instance != null)
            PlayerPowerController.Instance.LosePowerFromDamage();

        Debug.Log($"Player kena damage! Sisa nyawa: {lives}");

        if (lives <= 0)
        {
            Debug.Log("Player mati!");
        }
    }

    public void ResetHealth(int startingLives = 3)
    {
        lives = startingLives;
    }
}