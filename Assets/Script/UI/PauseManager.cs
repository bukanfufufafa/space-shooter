using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Referensi ke tulisan PAUSED
    [SerializeField] private GameObject pauseText;

    // Referensi ke panel setting, buat cek biar gak tabrakan input Escape
    [SerializeField] private GameObject panelSetting;

    // Menyimpan apakah game sedang pause
    private bool isPaused = false;

    private void Start()
    {
        // Pastikan saat game mulai tulisan tidak muncul
        pauseText.SetActive(false);
    }

    private void Update()
    {
        // Jika tombol ESC ditekan
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Kalau panel setting lagi kebuka, biarkan SettingUI yang handle Escape ini
            // (cukup nutup panel setting, jangan ikut toggle pause)
            if (panelSetting != null && panelSetting.activeSelf)
                return;

            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        // Menampilkan atau menyembunyikan tulisan
        pauseText.SetActive(isPaused);

        // Menghentikan atau menjalankan game
        Time.timeScale = isPaused ? 0f : 1f;
    }
}