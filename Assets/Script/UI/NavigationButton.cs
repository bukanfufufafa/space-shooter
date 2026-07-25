using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationButton : MonoBehaviour
{
   [Header("Panel")]
    public GameObject settingPanel;

    void Start()
    {
        settingPanel.SetActive(false);
    }
    public void Retry()
    {
        Debug.Log("Retry Game");

        // Nanti diganti menjadi:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        Debug.Log("Back To Main Menu");

        // Nanti diganti menjadi:
        // SceneManager.LoadScene("MainMenu");
    }

    public void OpenSetting()
    {
        settingPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseSetting()
    {
        settingPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
