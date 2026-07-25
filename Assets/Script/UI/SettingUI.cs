using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [Header("Slider")]
    public Slider bgmSlider;
    public Slider sfxSlider;

    private void Start()
    {
        // Nilai awal slider
        bgmSlider.value = PlayerPrefs.GetFloat("BGM", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFX", 1f);

        // Pasang event saat slider digeser
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }


    public void SetBGMVolume(float value)
    {
        PlayerPrefs.SetFloat("BGM", value);

        Debug.Log("BGM : " + value);

        // Nanti dihubungkan ke AudioManager
    }


    public void SetSFXVolume(float value)
    {
        PlayerPrefs.SetFloat("SFX", value);

        Debug.Log("SFX : " + value);

        // Nanti dihubungkan ke AudioManager
    }
}