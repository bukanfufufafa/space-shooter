using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;

    [Header("Score")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hi_scoreText;

    [Header("Player - Life")]
    public TextMeshProUGUI lifeLabelText;   // teks "Life :"
    public Transform lifeHolder;
    public GameObject heartPrefab;
    private List<Image> hearts = new List<Image>();

    [Header("Player - Skill")]
    public TextMeshProUGUI skillLabelText;  // teks "Skill :"
    public Transform skillHolder;
    public GameObject starPrefab;
    private List<Image> stars = new List<Image>();

    [Header("Player - Power")]
    public TextMeshProUGUI powerLabelText;  // teks "Power"
    public Image powerBar;
    private float powerLerpSpeed = 5f;
    private float targetPower;

    [Header("Ability")]
    public Image activeIcon;
    public TextMeshProUGUI deskActive;
    public Image passiveIcon;
    public TextMeshProUGUI deskPassive;

    [Header("Panel")]
    public GameObject settingPanel;
    public GameObject pausePanel;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Set label statis sekali di awal (aman walau belum di-assign)
        if (lifeLabelText != null) lifeLabelText.text = "Life :";
        if (skillLabelText != null) skillLabelText.text = "Skill :";
        if (powerLabelText != null) powerLabelText.text = "Power";
    }

    private void Update()
    {
        // Power bar cuma di-lerp kalau memang di-assign
        if (powerBar != null)
        {
            powerBar.fillAmount = Mathf.Lerp(
                powerBar.fillAmount,
                targetPower,
                powerLerpSpeed * Time.deltaTime
            );
        }
    }

    public void setScore(int score)
    {
        if (scoreText == null) return;
        scoreText.text = "Score : " + score.ToString();
    }

    public void setHighScore(int highScore)
    {
        if (hi_scoreText == null) return;
        hi_scoreText.text = "High Score : " + highScore.ToString();
    }

    public void setLife(int currentHP, int maxHP)
    {
        // Butuh holder DAN prefab, kalau salah satu kosong skip aja
        if (lifeHolder == null || heartPrefab == null) return;

        foreach (Transform child in lifeHolder)
        {
            Destroy(child.gameObject);
        }
        hearts.Clear();

        for (int i = 0; i < maxHP; i++)
        {
            GameObject obj = Instantiate(heartPrefab, lifeHolder);
            Image img = obj.GetComponent<Image>();
            if (img == null) continue; // jaga-jaga kalau prefab gak punya Image

            hearts.Add(img);
            img.color = i < currentHP ? Color.white : Color.gray;
        }
    }

    public void setSkill(int currentSkill, int maxSkill)
    {
        if (skillHolder == null || starPrefab == null) return;

        foreach (Transform child in skillHolder)
        {
            Destroy(child.gameObject);
        }
        stars.Clear();

        for (int i = 0; i < maxSkill; i++)
        {
            GameObject obj = Instantiate(starPrefab, skillHolder);
            Image img = obj.GetComponent<Image>();
            if (img == null) continue;

            stars.Add(img);
            img.color = i < currentSkill ? Color.white : Color.gray;
        }
    }

    public void setPower(float value)
    {
        targetPower = Mathf.Clamp01(value);
        // powerBar null-nya udah di-handle di Update()
    }

    public void showPause(bool value)
    {
        if (pausePanel == null) return;
        pausePanel.SetActive(value);
    }

    public void showSetting(bool value)
    {
        if (settingPanel == null) return;
        settingPanel.SetActive(value);
    }

    public void setActiveAbility(Sprite icon, string desc)
    {
        if (activeIcon != null) activeIcon.sprite = icon;
        if (deskActive != null) deskActive.text = desc;
    }

    public void setPassiveAbility(Sprite icon, string desc)
    {
        if (passiveIcon != null) passiveIcon.sprite = icon;
        if (deskPassive != null) deskPassive.text = desc;
    }
}