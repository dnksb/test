using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartBowling : MonoBehaviour
{
    [SerializeField] private CarController car;
    [SerializeField] private GameObject bowlingButton;
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject Win;
    [SerializeField] private GameObject WinMessage;


    [SerializeField] private List<KidTrigger> Kids = new List<KidTrigger>();


    public void StartEaseGame(GameObject controller)
    {
        car = controller.GetComponent<GameController>().Cars[controller.GetComponent<GameController>().CurrentCarIndex];
        foreach (KidTrigger item in Kids)
            item.StartBouling();

        bowlingButton.SetActive(false);

        car.GetComponent<CarRespawnController> ().enabled = false;
    	car.GetComponent<CarController>().enabled = true;
    	car.transform.position = new Vector3(-46, 27, -5924);
        car.transform.rotation = Quaternion.Euler(0, 180, 0);
    	camera.transform.position = new Vector3(-46, 27, -5924);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car")
        {
            car.GetComponent<CarController>().enabled = false;
            camera.GetComponent<CameraController> ().enabled = false;
            int amount = 0;
            foreach (KidTrigger item in Kids)
                if(item.IsBroke)
                    amount += 1;

            DataTable scoreboard;
            scoreboard = DataBase.GetTable($"SELECT level FROM players WHERE nickname = '{ChoiceCarMenu.Nickname}'");

            int maney = 0;

            foreach (DataRow row in scoreboard.Rows)
            {
                var cells = row.ItemArray;

                maney = int.Parse(cells[0].ToString());
            }
            var tmp1 = DataBase.ExecuteQueryWithAnswer(
                $"UPDATE players SET level = {maney + 100 * amount} WHERE nickname = '{ChoiceCarMenu.Nickname}'");

            Win.SetActive(true);
            WinMessage.transform.GetComponent<Text>().text = $"вы выйграли {100 * amount}$";
        }
    }

    public void CloseWin()
    {
        Win.SetActive(false);
        car.GetComponent<CarController>().enabled = true;
        camera.GetComponent<CameraController> ().enabled = true;
        car.GetComponent<CarRespawnController> ().enabled = true;

        car.transform.rotation = Quaternion.Euler(0, 0, 0);
        car.transform.position = new Vector3(-146.9f, 2, -86.5f);
    	camera.transform.position = new Vector3(-146.9f, 2, -86.5f);
    }
}
