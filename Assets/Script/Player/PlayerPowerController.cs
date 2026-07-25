using UnityEngine;


public class PlayerPowerController : MonoBehaviour
{
    public static PlayerPowerController Instance { get; private set; }

    [Header("Power Bar")]
    public float maxPower = 100f;
    public float currentPower = 0f;

    [Header("Efek Full Power")]
    [Range(0.1f, 1f)] public float fullPowerFireRateMultiplier = 0.5f;

    [Header("Referensi")]
    public PlayerShooting playerShooting;

    private bool isFullPower = false;

    private void Awake()
    {
        Instance = this;
    }

    public void AddPowerFromDamage(float damageDealt)
    {
        if (isFullPower) return;

        currentPower += damageDealt;

        if (currentPower >= maxPower)
        {
            currentPower = maxPower;
            EnterFullPowerMode();
        }
    }


    public void LosePowerFromDamage()
    {
        currentPower -= maxPower / 3f;
        if (currentPower < 0f) currentPower = 0f;

        if (isFullPower && currentPower < maxPower)
        {
            ExitFullPowerMode();
        }
    }

    private void EnterFullPowerMode()
    {
        isFullPower = true;
        playerShooting.SetFullPowerMode(true, fullPowerFireRateMultiplier);
        Debug.Log("Full Power Mode AKTIF! Fire rate meningkat.");
    }

    private void ExitFullPowerMode()
    {
        isFullPower = false;
        playerShooting.SetFullPowerMode(false, 1f);
        Debug.Log("Full Power Mode berakhir.");
    }

    public float GetPowerPercent() => currentPower / maxPower;

    /// <summary>Panggil pas mulai run baru.</summary>
    public void ResetPower()
    {
        currentPower = 0f;
        isFullPower = false;
        playerShooting.SetFullPowerMode(false, 1f);
    }
}