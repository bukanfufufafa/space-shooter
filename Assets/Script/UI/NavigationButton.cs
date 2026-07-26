using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationButton : MonoBehaviour
{
    [Header("Panel")]
    public GameObject settingPanel;
    public GameObject panelKonfirmasiRetry;
    public GameObject panelKonfirmasiHome;

    void Start()
    {
        settingPanel.SetActive(false);

        if (panelKonfirmasiRetry != null) panelKonfirmasiRetry.SetActive(false);
        if (panelKonfirmasiHome != null) panelKonfirmasiHome.SetActive(false);
    }

    // Dipanggil dari tombol Retry di UI
    public void Retry()
    {
        if (panelKonfirmasiRetry != null)
            panelKonfirmasiRetry.SetActive(true);
    }

    // Dipanggil dari tombol Home di UI
    public void Home()
    {
        if (panelKonfirmasiHome != null)
            panelKonfirmasiHome.SetActive(true);
    }

    // Dipanggil dari tombol "Ya" di panelKonfirmasiRetry
    public void KonfirmasiRetryYa()
    {
        if (panelKonfirmasiRetry != null)
            panelKonfirmasiRetry.SetActive(false);

        Debug.Log("Retry Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Dipanggil dari tombol "Batal" di panelKonfirmasiRetry
    public void KonfirmasiRetryBatal()
    {
        if (panelKonfirmasiRetry != null)
            panelKonfirmasiRetry.SetActive(false);
    }

    // Dipanggil dari tombol "Ya" di panelKonfirmasiHome
    public void KonfirmasiHomeYa()
    {
        if (panelKonfirmasiHome != null)
            panelKonfirmasiHome.SetActive(false);

        Debug.Log("Back To Main Menu");
        SceneManager.LoadScene("MainMenu");
    }

    // Dipanggil dari tombol "Batal" di panelKonfirmasiHome
    public void KonfirmasiHomeBatal()
    {
        if (panelKonfirmasiHome != null)
            panelKonfirmasiHome.SetActive(false);
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