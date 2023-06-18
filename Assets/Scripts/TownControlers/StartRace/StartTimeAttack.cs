using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Data;

public class StartTimeAttack : MonoBehaviour
{
    public GameObject Race;
    public GameObject Bet;

    public Transform musicName;
    public Transform music;

    public GameObject StartPlace;
    public GameObject StartButton;
    public GameController Controller;

    public GameObject WinMessage;
    public GameObject LoseMessage;

    public int AmountLaps;
    public int CurrentAmountLaps = 0;
    public int CurrentCheckPoint = 0;
    public int PriceOfWin;

    public Vector3 StartPosition;
    public Quaternion StartRotation;

    public DateTime StartTime;

    public int TimeToWin;

    [SerializeField] private GameObject camera;
    [SerializeField] private CarController car;

    public List<Transform> CheckPoint = new List<Transform>();

    public void Start()
    {
        Race.SetActive(false);
    }

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
        CurrentAmountLaps = 0;
        LoseMessage.SetActive(false);
        camera.GetComponent<CameraController> ().enabled = true;
        car.GetComponent<CarController>().enabled = true;
        car.GetComponent<CarRespawnController> ().enabled = true;
        car.transform.position = StartPosition;
        car.transform.rotation = StartRotation;
        car.GetComponent<CarRespawnController> ().StartRace(CheckPoint);
        StartTime = DateTime.Now;

        Bet.SetActive(false);
        Race.SetActive(true);

    }

    public void Update()
    {
        var ts = DateTime.Now - StartTime;
        musicName.GetComponent<Text>().text = Math.Floor(ts.TotalSeconds).ToString() + "с/" + TimeToWin.ToString() + "с";
        if(ts.TotalSeconds > TimeToWin)
            Lose();
    }

    void OnTriggerEnter(Collider other) {
        if(car.GetComponent<CarRespawnController>().CurrentCheckPoint >= (
            car.GetComponent<CarRespawnController>().CheckPoint.Count - 1))
        {
            if(AmountLaps <= car.GetComponent<CarRespawnController>().CurrentAmountLaps)
                {
                    Win();
                }
            else car.GetComponent<CarRespawnController>().CurrentAmountLaps += 1;
        }
    }

    public void Win()
    {
        music.GetComponent<PlayListController>().ChangeMusic();
        car.UpdateControls(0,0,true);
        WinMessage.SetActive(true);
        StartPlace.SetActive(true);
        Race.SetActive(false);
        car.GetComponent<CarRespawnController> ().RaceMode = false;

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
    	var tmp1 = DataBase.ExecuteQueryWithAnswer(
            $"UPDATE players SET level = {maney + PriceOfWin} WHERE nickname = '{ChoiceCarMenu.Nickname}'");

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
        StartPlace.SetActive(true);
    }

    public void Lose()
    {
        music.GetComponent<PlayListController>().ChangeMusic();
        car.UpdateControls(0,0,true);
        LoseMessage.SetActive(true);
        Race.SetActive(false);
        car.GetComponent<CarRespawnController> ().RaceMode = false;

        car.GetComponent<CarController>().enabled = false;
        car.GetComponent<CarRespawnController> ().enabled = false;
        camera.GetComponent<CameraController> ().enabled = false;
    }
}
