using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using System;

public class AddPlayerControl : MonoBehaviour
{

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject add_player;

    [SerializeField] private GameObject error_text;
    [SerializeField] private GameObject textBox;

    [SerializeField] string car_uid;
    [SerializeField] string car_name;

    private bool HaveNicknameInBD(string nickname)
    {
        bool found = false;
        DataTable scoreboard = DataBase.GetTable("SELECT * FROM players");

        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;

            foreach (object cell in cells)
            {
                if(cell.ToString() == nickname)
                {
                    found = true;
                }
            }
        }
        return found;
    }

    public void AddPlayer()
    {
        string nickname = textBox.transform.GetChild(2).gameObject.GetComponent<Text>().text;
        if(HaveNicknameInBD(nickname))
        {
            error_text.SetActive(true);
        }
        else
        {
            DataBase.ExecuteQueryWithoutAnswer(
                $"INSERT INTO players (nickname, level, progress) VALUES ('{nickname}',{500}, {1})");
		
		DataBase.ExecuteQueryWithoutAnswer($"CREATE TABLE'{nickname}' ('id_car' TEXT NOT NULL, 'car' TEXT NOT NULL, 'car_power' INTEGER NOT NULL)");
            Guid myuuid = Guid.NewGuid();
            car_uid = myuuid.ToString();
            car_name = "Crown 1985";
            DataBase.ExecuteQueryWithoutAnswer(
                $"INSERT INTO '{nickname}' (id_car, car, car_power) VALUES ('{car_uid}', '{car_name}', 280)");
	    	DataBase.ExecuteQueryWithoutAnswer(
                $"INSERT INTO 'all cars set' VALUES ('{car_uid}', 'stock_crown_front_fender', 'stock_crown_back_fender', 'stock_crown_front_bumper', 'stock_crown_back_bumper', 'stock_crown_threshold')");
	     	DataBase.ExecuteQueryWithoutAnswer(
                $"INSERT INTO 'car tech set' VALUES ('{car_uid}', '2', '2', '2', '2')");
        }
    }

    public void CloseAddPlayer()
    {
        menu.SetActive(true);
        add_player.SetActive(false);
    }

}
