using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int currentScore;
    private int highScore;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Contoh sementara
        highScore = 5000;

        HUDManager.Instance.setScore(currentScore);
        HUDManager.Instance.setHighScore(highScore);
    }

    // Menambah score
    public void AddScore(int amount)
    {
        currentScore += amount;

        // Jika score sekarang lebih tinggi
        if (currentScore > highScore)
        {
            highScore = currentScore;
            HUDManager.Instance.setHighScore(highScore);
        }

        HUDManager.Instance.setScore(currentScore);
    }

    // Mengembalikan score sekarang
    public int GetScore()
    {
        return currentScore;
    }
}