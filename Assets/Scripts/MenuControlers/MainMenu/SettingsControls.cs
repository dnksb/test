using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsControls : MonoBehaviour
{
    [SerializeField] private GameObject main_menu;
    [SerializeField] private GameObject settings;
    [SerializeField] private Scrollbar scrol_bar;
    [SerializeField] private bool isFullScreen = true;
    [SerializeField] private AudioMixer am;

    public void InterfeisPressed()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void AudioVolume()
    {
        float sliderValue = (-80) + scrol_bar.value * 100;
        am.SetFloat("masterVolume", sliderValue);
    }

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }
    
    public void MenuPressed()
    {
        main_menu.SetActive(true);
        settings.SetActive(false);
    }
}
