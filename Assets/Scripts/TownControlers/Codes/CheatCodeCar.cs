using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheatCodeCar : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject truck;
    [SerializeField] private GameObject truckTrailer;
    [SerializeField] private GameObject supertruck;
    [SerializeField] private GameObject del;
    [SerializeField] private GameObject tank;
    [SerializeField] private GameObject gaz;

    public void Interpretetor(GameObject textBox)
    {
    	string code = textBox.GetComponent<Text>().text;
    	if(code == "insert car")
    	{
            InsertCar();
    	}
    	else if(code == "insert truck")
    	{
            InsertTruck();
    	}
    	else if(code == "insert supertruck")
    	{
            InsertSuperTruck();
    	}
    	else if(code == "insert trailer")
    	{
            InsertTrailer();
    	}
    	else if(code == "insert del")
    	{
            InsertDel();
    	}
        else if(code == "insert tank")
    	{
            InsertTank();
    	}
        else if(code == "insert gaz")
    	{
            InsertGaz();
    	}
    	else if(code == "1000")
    	{
            AddManey();
    	}

    }

    public void InsertCar()
    {
    	Instantiate(car);
    }

    public void InsertTruck()
    {
    	Instantiate(truck);
    }
    public void InsertSuperTruck()
    {
    	Instantiate(supertruck);
    }

    public void InsertTrailer()
    {
    	Instantiate(truckTrailer);
    }

    public void InsertDel()
    {
    	Instantiate(del);
    }

    public void InsertTank()
    {
    	Instantiate(tank);
    }

    public void InsertGaz()
    {
    	Instantiate(gaz);
    }

    public void AddManey()
    {
    	DataTable scoreboard;
        scoreboard = DataBase.GetTable($"SELECT level FROM players WHERE nickname = '{ChoiceCarMenu.Nickname}'");

        int maney = 0;

        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;

	    maney = int.Parse(cells[0].ToString());
        }
    	var tmp1 = DataBase.ExecuteQueryWithAnswer($"UPDATE players SET level = {maney + 1000} WHERE nickname = '{ChoiceCarMenu.Nickname}'");
    }
}
