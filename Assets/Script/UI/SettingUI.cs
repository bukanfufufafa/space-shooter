using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject panelSetting; // panel setting yang mau ditutup

    [Header("Slider")]
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    private void Start()
    {
        // Ambil nilai yang disimpan
        masterSlider.value = PlayerPrefs.GetFloat("MASTER", 1f);
        bgmSlider.value = PlayerPrefs.GetFloat("BGM", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFX", 1f);

        // Pasang event
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        // Terapkan volume pertama kali
        UpdateVolume();
    }

    private void Update()
    {
        // Kalau panel gak aktif, gak perlu cek input apa-apa
        if (panelSetting != null && !panelSetting.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TutupPanel();
        }
    }

    public void SetMasterVolume(float value)
    {
        PlayerPrefs.SetFloat("MASTER", value);
        UpdateVolume();
    }

    public void SetBGMVolume(float value)
    {
        PlayerPrefs.SetFloat("BGM", value);
        UpdateVolume();
    }

    public void SetSFXVolume(float value)
    {
        PlayerPrefs.SetFloat("SFX", value);
        UpdateVolume();
    }

    private void UpdateVolume()
    {
        float master = masterSlider.value;
        float bgm = bgmSlider.value;
        float sfx = sfxSlider.value;

        float finalBGM = master * bgm;
        float finalSFX = master * sfx;

        Debug.Log("Master : " + master);
        Debug.Log("Final BGM : " + finalBGM);
        Debug.Log("Final SFX : " + finalSFX);

        // Nanti dihubungkan ke AudioManager
        // AudioManager.Instance.SetBGMVolume(finalBGM);
        // AudioManager.Instance.SetSFXVolume(finalSFX);
    }

    // Dipanggil dari tombol Exit, atau dari Escape di Update()
    public void TutupPanel()
    {
        if (panelSetting != null)
            panelSetting.SetActive(false);
    }
}