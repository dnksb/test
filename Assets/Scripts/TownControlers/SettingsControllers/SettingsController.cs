using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
	[SerializeField] private GameObject music;
	[SerializeField] private GameObject controllers;
	[SerializeField] private GameObject settings;
	[SerializeField] KeyCode stopkey; 
	[SerializeField] private bool showing = false;	
	[SerializeField] private bool manual = true;	
	[SerializeField] private bool show_controllers = false;	
	[SerializeField] private AudioMixer am;
	[SerializeField] private Scrollbar scrol_bar;
	[SerializeField] private CarController wheels;
	
	
    void Update()
    {
		if(Input.GetKeyDown (stopkey) && !showing)
		{
			ShowSettings();
		}
		else if(Input.GetKeyDown (stopkey) && showing)
		{
			CloseSettings();
		}
    }
    
    public void ShowSettings()
    {
    	settings.SetActive(true);
    	controllers.SetActive(show_controllers);
    	music.SetActive(show_controllers);
    }
    
    public void CloseSettings()
    {
    	settings.SetActive(false);
    	controllers.SetActive(show_controllers);
   	music.SetActive(show_controllers);
    }
    
    public void ShowControllers()
    {
	show_controllers = !show_controllers;
    }
    
    public void AudioVolume()
    {
        float sliderValue = (-80) + scrol_bar.value * 100;
        am.SetFloat("masterVolume", sliderValue);
    }
    
    public void GearBoxMode()
    {
    	manual = !manual;
    	wheels.AutomaticGearbox = manual;
    }
    
    public void BackMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
