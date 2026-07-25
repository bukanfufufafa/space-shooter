using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    [Header("Tombol Menu Utama")]
    public Button playBtn;
    public Button settingBtn;
    public Button creditBtn;
    public Button quitBtn;

    [Header("Tombol Tutup Panel")]
    public Button closeCreditBtn;

    [Header("Panel")]
    [SerializeField] private GameObject panelSetting;
    [SerializeField] private GameObject panelCredit;

    [Header("Scene")]
    [SerializeField] private string namaSceneGameplay;

    private void Start()
    {
        // Pastikan panel tertutup di awal
        if (panelSetting != null) panelSetting.SetActive(false);
        if (panelCredit != null) panelCredit.SetActive(false);

        // Pasang event ke tiap tombol
        playBtn.onClick.AddListener(MainkanGame);
        settingBtn.onClick.AddListener(BukaSetting);
        creditBtn.onClick.AddListener(BukaCredit);
        quitBtn.onClick.AddListener(KeluarGame);

        if (closeCreditBtn != null)
            closeCreditBtn.onClick.AddListener(TutupCredit);
    }

    private void Update()
    {
        // Escape cuma nutup panel credit kalau lagi kebuka
        if (panelCredit != null && panelCredit.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            TutupCredit();
        }
    }

    private void MainkanGame()
    {
        if (string.IsNullOrEmpty(namaSceneGameplay))
        {
            Debug.LogWarning("Nama scene gameplay belum diisi di Inspector!");
            return;
        }

        SceneManager.LoadScene(namaSceneGameplay);
    }

    private void BukaSetting()
    {
        if (panelSetting != null)
            panelSetting.SetActive(true);
    }

    private void BukaCredit()
    {
        if (panelCredit != null)
            panelCredit.SetActive(true);
    }

    private void TutupCredit()
    {
        if (panelCredit != null)
            panelCredit.SetActive(false);
    }

    private void KeluarGame()
    {
        Debug.Log("Keluar game...");

#if UNITY_EDITOR
        // Biar bisa dites di Editor (Application.Quit() gak jalan di Editor)
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}