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

    public GameObject WinText;
    public int CurrentLevel;
    public string HistoryText;

    public GameObject TextLap;

    public bool IsBet;

    public GameObject StartPlace;
    public GameObject StartButton;
    public GameController Controller;

    public GameObject WinMessage;
    public GameObject LoseMessage;

    public int AmountLaps;
    public int CurrentAmountLaps = 1;
    public int PriceOfWin;

    public Vector3 StartPosition;
    public Quaternion StartRotation;

    [SerializeField] private GameObject camera;
    public List<AIController> Cars = new List<AIController>();
    [SerializeField] private CarController car;

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

    public void ApplyBet()
    {
        DataTable scoreboard;
        scoreboard = DataBase.GetTable($"SELECT level FROM players WHERE nickname = '{ChoiceCarMenu.Nickname}'");

        int maney = 0;

        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;

	        maney = int.Parse(cells[0].ToString());
        }
        if(maney > 100)
            IsBet = true;
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

        int tmp = car.GetComponent<CarRespawnController>().CurrentAmountLaps;
        if(AmountLaps <= ++tmp)
            TextLap.transform.GetComponent<Text>().text = "ФИНИШ";
        else
            {TextLap.transform.GetComponent<Text>().text =
                "КРУГ " + tmp.ToString();}

        Bet.SetActive(false);
        foreach (var carbot in Cars)
        {
            carbot.StartRace();
            carbot.SetActive(true);
            carbot.CurrentCheckPoint = 0;
        }
        Race.SetActive(true);
        car.GetComponent<CarRespawnController> ().StartRace(Cars[0].CheckPoint);

    }

    void OnTriggerEnter(Collider other) {

        if(other.tag == "Car")
            if(car.GetComponent<CarRespawnController>().CurrentCheckPoint >= (
                car.GetComponent<CarRespawnController>().CheckPoint.Count - 1))
            {
                int tmp = car.GetComponent<CarRespawnController>().CurrentAmountLaps;
                if(AmountLaps <= tmp)
                    Win();
                else car.GetComponent<CarRespawnController>().CurrentAmountLaps += 1;
                if(AmountLaps <= ++tmp)
                    TextLap.transform.GetComponent<Text>().text = "ФИНИШ";
                else
                    {TextLap.transform.GetComponent<Text>().text =
                        "КОНЕЦ КРУГ " + (tmp + 1).ToString();}
            }
        else if(other.tag == "Bot")
            Debug.Log((other.GetComponent<AIController>().CheckPoint.Count - 1));
            if(other.GetComponent<AIController>().CurrentCheckPoint >= (
                other.GetComponent<AIController>().CheckPoint.Count - 1))
            {
                int tmp = other.GetComponent<AIController>().CurrentAmountLaps;
                if(AmountLaps <= tmp)
                    Lose();
                else
                {
                    other.GetComponent<AIController>().CurrentAmountLaps += 1;
                    other.GetComponent<AIController>().CurrentCheckPoint = MathExtentions.LoopClamp (
                        other.GetComponent<AIController>().CurrentCheckPoint + 1,
                        0,
                        other.GetComponent<AIController>().CheckPoint.Count);
                }
            }
    }

    public void Win()
    {
        car.UpdateControls(0,0,true);
        WinMessage.SetActive(true);
        StartPlace.SetActive(true);
        Race.SetActive(false);
        foreach (var carbot in Cars)
            carbot.SetActive(false);

        car.GetComponent<CarRespawnController> ().RaceMode = false;

        car.GetComponent<CarController>().enabled = false;
        car.GetComponent<CarRespawnController> ().enabled = false;
        camera.GetComponent<CameraController> ().enabled = false;

        DataTable scoreboard;
        scoreboard = DataBase.GetTable($"SELECT level, progress FROM players WHERE nickname = '{ChoiceCarMenu.Nickname}'");

        int maney = 0;
        int level = 0;

        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;

	        maney = int.Parse(cells[0].ToString());
            level = int.Parse(cells[1].ToString());
        }
        string text = "";
        Debug.Log(level);
        if(level == CurrentLevel)
        {
            text = HistoryText;
        }
        if(IsBet)
        {
            text += $"вы победили\n+100$\n+{PriceOfWin}$";
            var tmp1 = DataBase.ExecuteQueryWithAnswer(
                $"UPDATE players SET level = {maney + PriceOfWin + 100} WHERE nickname = '{ChoiceCarMenu.Nickname}'");}
        else
        {
            text += $"вы победили\n+{PriceOfWin}$";
            var tmp1 = DataBase.ExecuteQueryWithAnswer(
                $"UPDATE players SET level = {maney + PriceOfWin} WHERE nickname = '{ChoiceCarMenu.Nickname}'");}
        WinText.transform.GetComponent<Text>().text = text;
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
        car.UpdateControls(0,0,true);
        LoseMessage.SetActive(true);
        Race.SetActive(false);
        car.GetComponent<CarRespawnController> ().RaceMode = false;

        DataTable scoreboard;
        scoreboard = DataBase.GetTable($"SELECT level FROM players WHERE nickname = '{ChoiceCarMenu.Nickname}'");

        int maney = 0;

        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;

	        maney = int.Parse(cells[0].ToString());
        }
        if(IsBet)
        {var tmp1 = DataBase.ExecuteQueryWithAnswer(
                $"UPDATE players SET level = {maney - 100} WHERE nickname = '{ChoiceCarMenu.Nickname}'");}

        foreach (var carbot in Cars)
            carbot.SetActive(false);
        car.GetComponent<CarController>().enabled = false;
        car.GetComponent<CarRespawnController> ().enabled = false;
        camera.GetComponent<CameraController> ().enabled = false;
    }
}


/*
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public Texture2D screenTexture;
    private static LoadingScreen instance;
    private static AsyncOperation syncLevel;
    private static bool doneLoadingScene;

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        gameObject.AddComponent<GUITexture>().enabled = false;
        guiTexture.texture = screenTexture;
        transform.position = new Vector3(0.5f, 0.5f, 0.0f);
        DontDestroyOnLoad(this);
    }

    public static void Load(string name)
    {
        if (!instance) return;
        instance.guiTexture.enabled = true;
        syncLevel = Application.LoadLevelAsync(name);
        doneLoadingScene = true;
    }

    public void Update()
    {
        if (doneLoadingScene && syncLevel.isDone)
        {
            doneLoadingScene = false;
            instance.guiTexture.enabled = false;
        }
    }
}

*/
