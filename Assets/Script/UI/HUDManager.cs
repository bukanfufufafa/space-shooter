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
    [Header("Player")]
    public Transform lifeHolder;

    // Prefab hati
    public GameObject heartPrefab;

    private List<Image> hearts = new List<Image>();

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
    private void Update()
    {
        powerBar.fillAmount = Mathf.Lerp(
            powerBar.fillAmount,
            targetPower,
            powerLerpSpeed * Time.deltaTime
        );
    }
    public void setScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void setHighScore(int highScore)
    {
        hi_scoreText.text = highScore.ToString();
    }
    public void setLife(int currentHP, int maxHP)
    {
        // Hapus icon lama
        foreach (Transform child in lifeHolder)
        {
            Destroy(child.gameObject);
        }

        hearts.Clear();

        // Buat icon baru
        for (int i = 0; i < maxHP; i++)
        {
            GameObject obj = Instantiate(heartPrefab, lifeHolder);

            Image img = obj.GetComponent<Image>();

            hearts.Add(img);

            // Jika index masih di bawah currentHP
            // maka icon aktif
            img.color = i < currentHP ? Color.white : Color.gray;
        }
    }
    public void setPower(float value)
    {
        targetPower = Mathf.Clamp01(value);
    }
    public void showPause(bool value)
    {
        pausePanel.SetActive(value);
    }
    public void showSetting(bool value)
    {
        settingPanel.SetActive(value);
    }
}
