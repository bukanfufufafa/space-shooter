using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerHealth : MonoBehaviour
{
    public int lives = 3;

    [Header("Hit Feedback")]
    public float invincibilityDuration = 1f;   
    public float blinkInterval = 0.1f;      
    public Color hitColor = Color.red;       
    [Range(0f, 1f)] public float hitAlpha = 0.6f;

    private SpriteRenderer spriteRenderer;
    private Color normalColor;
    private bool isInvincible = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        normalColor = spriteRenderer.color;
    }

    public void AddExtraLives(int amount)
    {
        lives += amount;
        Debug.Log($"Nyawa nambah! Total sekarang: {lives}");
    }

    /// <summary>Panggil ini dari mana pun player kena serangan musuh.</summary>
    public void TakeDamage(int amount)
    {
        if (isInvincible) return; // lagi i-frame, damage diabaikan

        lives -= amount;

        if (PlayerPowerController.Instance != null)
            PlayerPowerController.Instance.LosePowerFromDamage();

        Debug.Log($"Player kena damage! Sisa nyawa: {lives}");

        if (lives <= 0)
        {
            Debug.Log("Player mati!");
            // TODO: logic game over
            return;
        }

        StartCoroutine(HitFeedbackRoutine());
    }

    private IEnumerator HitFeedbackRoutine()
    {
        isInvincible = true;
        float elapsed = 0f;
        bool showHitColor = true;

        while (elapsed < invincibilityDuration)
        {
            spriteRenderer.color = showHitColor
                ? new Color(hitColor.r, hitColor.g, hitColor.b, hitAlpha)
                : new Color(normalColor.r, normalColor.g, normalColor.b, hitAlpha);

            showHitColor = !showHitColor;

            yield return new WaitForSecondsRealtime(blinkInterval);
            elapsed += blinkInterval;
        }

        spriteRenderer.color = normalColor; // balikin ke kondisi normal
        isInvincible = false;
    }

    /// <summary>Panggil pas mulai run baru.</summary>
    public void ResetHealth(int startingLives = 3)
    {
        lives = startingLives;
        isInvincible = false;
        StopAllCoroutines();
        if (spriteRenderer != null) spriteRenderer.color = normalColor;
    }
}