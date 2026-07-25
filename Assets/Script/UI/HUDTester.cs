using UnityEngine;

public class HUDTester : MonoBehaviour
{
    private int score = 0;
    private int life = 3;
    private float power = 0;

    void Start()
    {
        HUDManager.Instance.setScore(score);
        HUDManager.Instance.setHighScore(5000);
        HUDManager.Instance.setLife(3, 5);
        HUDManager.Instance.setPower(power);
    }

    void Update()
    {
        // Tambah Score
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ScoreManager.Instance.AddScore(100);
        }

        // Kurangi HP
        if (Input.GetKeyDown(KeyCode.W))
        {
            life--;

            if (life < 0)
                life = 0;

            HUDManager.Instance.setLife(life, 5);
        }

        // Tambah Power
        if (Input.GetKeyDown(KeyCode.E))
        {
            power += 1f;

            if (power > 1)
                power = 1;

            HUDManager.Instance.setPower(power);
        }// Kurangi Power
        if (Input.GetKeyDown(KeyCode.R))
        {
            power -= 0.2f;

            if (power < 0)
                power = 0;

            HUDManager.Instance.setPower(power);
        }
    }
}