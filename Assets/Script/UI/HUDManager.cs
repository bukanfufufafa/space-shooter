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
    public Image[] iconHealth;
    public Image powerBar;
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
        Instance =  this;
    }
    public void setScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void setHighScore (int highScore)
    {
        hi_scoreText.text = highScore.ToString();
    }
    public void setLife(int currentLife)
    {
        for (int i = 0; i < iconHealth.Length; i++)
        {
            iconHealth[i].enabled = i<currentLife;
        }
    }
    public void setPower(float value)
    {
        powerBar.fillAmount = value;
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
