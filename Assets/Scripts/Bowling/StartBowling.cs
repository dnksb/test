using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBowling : MonoBehaviour
{
    [SerializeField] private GameObject dificult;
    [SerializeField] private CarController car;
    [SerializeField] private GameObject bowlingButton;
    [SerializeField] private GameObject camera;
    
    
    public void ShowDificult(GameObject controller)
    {
    	car = controller.GetComponent<GameController>().Cars[controller.GetComponent<GameController>().CurrentCarIndex];
    
    	dificult.SetActive(true);
    	bowlingButton.SetActive(false);
    	car.GetComponent<CarController>().enabled = false;
    }
    
    public void StartEaseGame()
    {
    	car.GetComponent<CarController>().enabled = true;    
     	dificult.SetActive(false);
    	car.transform.position = new Vector3(-50, 28, -6000);
    	camera.transform.position = new Vector3(-50, 28, -6000);
    }
    
    public void StartMiddleGame()
    {
        car.GetComponent<CarController>().enabled = true;    
     	dificult.SetActive(false);
    	car.transform.position = new Vector3(-50, 28, -6000);
    	camera.transform.position = new Vector3(-50, 28, -6000);
    }
    
    public void StartHardGame()
    {
	car.GetComponent<CarController>().enabled = true;    
     	dificult.SetActive(false);
    	car.transform.position = new Vector3(-50, 28, -6000);
    	camera.transform.position = new Vector3(-50, 28, -6000);
    }
}
