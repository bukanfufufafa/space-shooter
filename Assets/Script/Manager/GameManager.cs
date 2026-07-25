using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Referensi Player")]
    public PlayerSkillController playerSkillController;
    public PlayerShooting playerShooting;
    public PlayerHealth playerHealth;
    public PlayerPowerController playerPowerController;

    [Header("Referensi Stage")]
    public StageManager stageManager;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartNewRun();
    }

    public void StartNewRun()
    {
        playerSkillController.ResetSkill();
        playerShooting.ResetPassives();
        playerHealth.ResetHealth();
        playerPowerController.ResetPower();
        stageManager.ResetStage();

        Debug.Log("Run baru dimulai! Semua skill & stat direset.");
    }
}