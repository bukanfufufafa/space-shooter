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

    [Header("Full Power Sprite")]
    public SpriteRenderer playerSpriteRenderer;
    public Sprite normalSprite;
    public Sprite fullPowerSprite;

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

        if (playerSpriteRenderer != null && fullPowerSprite != null)
            playerSpriteRenderer.sprite = fullPowerSprite;

        Debug.Log("Full Power Mode AKTIF! Fire rate meningkat.");
    }

    private void ExitFullPowerMode()
    {
        isFullPower = false;
        playerShooting.SetFullPowerMode(false, 1f);

        if (playerSpriteRenderer != null && normalSprite != null)
            playerSpriteRenderer.sprite = normalSprite;

        Debug.Log("Full Power Mode berakhir.");
    }

    public float GetPowerPercent() => currentPower / maxPower;

    public void ForceFullPower()
    {
        currentPower = maxPower;
        EnterFullPowerMode();
    }

    public void ResetPower()
    {
        currentPower = 0f;
        isFullPower = false;
        playerShooting.SetFullPowerMode(false, 1f);

        if (playerSpriteRenderer != null && normalSprite != null)
            playerSpriteRenderer.sprite = normalSprite;
    }
}