using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartRace1 : MonoBehaviour
{
    public GameObject Race;
    public GameObject Bet;
    public GameObject StartPlace;
    public GameObject StartButton;
    public GameController Controller;
    public GameObject WinMessage;
    public GameObject LoseMessage;
    public int PriceOfWin;
    [SerializeField] private GameObject camera;
    public List<AIController> Cars = new List<AIController>();
    [SerializeField] private CarController car;

    public void ShowBet()
    {
        StartButton.SetActive(false);
        StartPlace.SetActive(false);

        car = Controller.Cars[Controller.CurrentCarIndex];
        car.UpdateControls(0,0,true);
        car.GetComponent<CarController>().enabled = false;
        car.GetComponent<CarRespawnController> ().enabled = false;

        camera.GetComponent<CameraController> ().enabled = false;
        Bet.SetActive(true);
    }

    public void StartRace()
    {
        LoseMessage.SetActive(false);
        camera.GetComponent<CameraController> ().enabled = true;

        car.GetComponent<CarController>().enabled = true;
        car.GetComponent<CarRespawnController> ().enabled = true;
        car.transform.position = new Vector3(-259.24f, 7.61f, 236.3913f);
        car.transform.rotation = Quaternion.Euler(0, 90, 0);

        Bet.SetActive(false);
        Race.SetActive(true);

        foreach (var car in Cars)
            car.SetActive(true);
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Car")
            Win();
        else if(other.tag == "Bot")
            Lose();
    }

    public void Win()
    {
        car.UpdateControls(0,0,true);
        WinMessage.SetActive(true);
        StartPlace.SetActive(true);
        Race.SetActive(false);
        foreach (var car in Cars)
            car.SetActive(false);

        car.GetComponent<CarController>().enabled = false;
        car.GetComponent<CarRespawnController> ().enabled = false;
        camera.GetComponent<CameraController> ().enabled = false;

        DataTable scoreboard;
        scoreboard = DataBase.GetTable($"SELECT level FROM players WHERE nickname = '{ChoiceCarMenu.Nickname}'");

        int maney = 0;

        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;

	        maney = int.Parse(cells[0].ToString());
        }
    	var tmp1 = DataBase.ExecuteQueryWithAnswer($"UPDATE players SET level = {maney + PriceOfWin} WHERE nickname = '{ChoiceCarMenu.Nickname}'");

    }

    public void WinMessageClose()
    {
        WinMessage.SetActive(false);
        car.GetComponent<CarController>().enabled = true;
        car.GetComponent<CarRespawnController> ().enabled = true;
        camera.GetComponent<CameraController> ().enabled = true;
    }

    public void LoseMessageClose()
    {
        LoseMessage.SetActive(false);
        car.GetComponent<CarController>().enabled = true;
        car.GetComponent<CarRespawnController> ().enabled = true;
        camera.GetComponent<CameraController> ().enabled = true;
    }

    public void Lose()
    {
        car.UpdateControls(0,0,true);
        LoseMessage.SetActive(true);
        StartPlace.SetActive(true);
        Race.SetActive(false);

        foreach (var car in Cars)
            car.SetActive(false);
        car.GetComponent<CarController>().enabled = false;
        car.GetComponent<CarRespawnController> ().enabled = false;
        camera.GetComponent<CameraController> ().enabled = false;
    }
}
