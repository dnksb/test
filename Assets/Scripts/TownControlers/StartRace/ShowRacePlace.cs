using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowRacePlace : MonoBehaviour
{

    public GameObject Place1;
    public GameObject Place2;
    public GameObject Place3;
    public GameObject Place4;
    public GameObject Place5;

    void Start()
    {
        DataTable scoreboard;
        scoreboard = DataBase.GetTable($"SELECT level FROM players WHERE nickname = '{ChoiceCarMenu.Nickname}'");

        int maney = 0;

        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;

	        maney = int.Parse(cells[0].ToString());
        }

        switch (maney)
        {
            case 1:
                Level1();
                break;
            case 2:
                Level2();
                break;
            default:
                Level3();
                break;
        }
    }

    public void Level1()
    {
        Place1.SetActive(true);
        Place2.SetActive(false);
        Place3.SetActive(false);
        Place4.SetActive(true);
        Place5.SetActive(true);
    }
    public void Level2()
    {
        Place1.SetActive(true);
        Place2.SetActive(true);
        Place3.SetActive(false);
        Place4.SetActive(true);
        Place5.SetActive(true);
    }
    public void Level3()
    {
        Place1.SetActive(true);
        Place2.SetActive(true);
        Place3.SetActive(true);
        Place4.SetActive(true);
        Place5.SetActive(true);
    }

    void UpdateLevel()
    {
        DataTable scoreboard;
        scoreboard = DataBase.GetTable($"SELECT level FROM players WHERE nickname = '{ChoiceCarMenu.Nickname}'");

        int maney = 0;

        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;

	        maney = int.Parse(cells[0].ToString());
        }

        switch (maney)
        {
            case 1:
                Level1();
                break;
            case 2:
                Level2();
                break;
            default:
                Level3();
                break;
        }
    }
}
