using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsController : MonoBehaviour
{
	[SerializeField] private GameObject music;
	[SerializeField] private CarController car;
	[SerializeField] private GameObject controllers;
	[SerializeField] private GameObject settings;
	[SerializeField] private GameObject camera;
	[SerializeField] KeyCode stopkey;
	[SerializeField] private bool showing = false;
	[SerializeField] private bool manual = true;
	[SerializeField] private bool show_controllers = false;
	[SerializeField] private AudioMixer am;
	[SerializeField] private Scrollbar scrol_bar;
	[SerializeField] private CarController wheels;


    void Update()
    {
		car = GetComponent<GameController>().Cars[GetComponent<GameController>().CurrentCarIndex];
		if(Input.GetKeyDown (stopkey) && !showing)
		{

			car.GetComponent<CarController>().enabled = false;
			ShowSettings();
		}
		else if(Input.GetKeyDown (stopkey) && showing)
		{
			car.GetComponent<CarController>().enabled = true;
			CloseSettings();
		}
    }

    public void ShowSettings()
    {
    	car.GetComponent<CarController>().enabled = false;
    	car.GetComponent<CarRespawnController> ().enabled = false;
    	GetComponent<GameController> ().enabled = false;
    	camera.GetComponent<CameraController> ().enabled = false;
    	settings.SetActive(true);
    	controllers.SetActive(show_controllers);
    	music.SetActive(show_controllers);
    }

    public void CloseSettings()
    {
		camera.GetComponent<CameraController> ().enabled = true;
    	car.GetComponent<CarController>().enabled = true;
    	car.GetComponent<CarRespawnController> ().enabled = true;
    	GetComponent<GameController> ().enabled = true;
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
