using UnityEngine;

/// <summary>
/// Power bar naik dari total damage yang player kasih ke musuh,
/// dan berkurang 1/3 tiap kali player kena damage.
/// Full Power aktif SELAMA bar penuh - begitu bar turun (karena kena hit), otomatis mati.
/// </summary>
public class PlayerPowerController : MonoBehaviour
{
    // Singleton biar gampang diakses dari PlayerBullet & PlayerHealth
    // yang notabene ada di GameObject beda
    public static PlayerPowerController Instance { get; private set; }

    [Header("Power Bar")]
    public float maxPower = 100f;
    public float currentPower = 0f;

    [Header("Efek Full Power")]
    [Range(0.1f, 1f)] public float fullPowerFireRateMultiplier = 0.5f; // makin kecil = makin cepat nembak

    [Header("Referensi")]
    public PlayerShooting playerShooting;

    private bool isFullPower = false;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>Panggil ini tiap kali bullet player ngasih damage ke musuh.</summary>
    public void AddPowerFromDamage(float damageDealt)
    {
        if (isFullPower) return; // udah penuh, gak nambah lagi sampai turun lagi

        currentPower += damageDealt;

        if (currentPower >= maxPower)
        {
            currentPower = maxPower;
            EnterFullPowerMode();
        }
    }

    /// <summary>Panggil ini tiap kali player kena damage.</summary>
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
}
