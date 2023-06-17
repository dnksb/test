using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using System;

public class DropDownShop : MonoBehaviour
{
    [SerializeField] Dropdown cars_name;

    [SerializeField] Text name;

    [SerializeField] string nickname;

    [SerializeField] string car_uid;

    [SerializeField] string car_name;

    // Start is called before the first frame update
    void Start()
    {
    	nickname = ChoiceUserControler.GetPlayerNickname();

    	SetDropDown();
    }

    public void CloseGarage()
    {
        SceneManager.LoadScene("Garage");
    }

    public bool CheckPrice(int price)
    {
    	DataTable scoreboard;
        scoreboard = DataBase.GetTable($"SELECT level FROM players WHERE nickname = '{ChoiceCarMenu.Nickname}'");

        int maney = 0;

        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;

	    maney = int.Parse(cells[0].ToString());
        }

        if(maney < price)
        {
        	return false;
        }
        var tmp1 = DataBase.ExecuteQueryWithAnswer(
			$"UPDATE players SET level = {maney - price} WHERE nickname = '{ChoiceCarMenu.Nickname}'");
    	return true;
    }

    public void BuyCar()
    {

    	Guid myuuid = Guid.NewGuid();
        car_uid = myuuid.ToString();

        car_name = name.text;

    	CreateOtherRecord();
    }

    void CreateOtherRecord()
    {
	switch(car_name)
	{
	    case "Prius 20":
	    	if(CheckPrice(400))
	    	{
	    		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO '{nickname}' (id_car, car, car_power) VALUES ('{car_uid}', '{car_name}', 76)");
	     		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO 'all cars set' VALUES ('{car_uid}', 'stock_prius20_front_fender', 'stock_prius20_back_fender', 'ralie_prius20_front_bumper', 'stock_prius20_back_bumper', 'stock_prius20_threshold')");
	     		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO 'car tech set' VALUES ('{car_uid}', '2', '2', '2', '2')");
	     	}
	    	break;
	    case "Porshe 911 turbo":
	    	if(CheckPrice(500))
	    	{
	    		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO '{nickname}' (id_car, car, car_power) VALUES ('{car_uid}', '{car_name}', 200)");
	    		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO 'all cars set' VALUES ('{car_uid}', 'stock_porshe911_front_fender', 'stock_porshe911_back_fender', 'stock_porshe911_front_bumper', 'stock_porshe911_back_bumper', 'stock_porshe911_threshold')");
	     		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO 'car tech set' VALUES ('{car_uid}', '2', '2', '2', '2')");
	     	}
	    	break;
	    case "Crown 1985":
	    	if(CheckPrice(200))
	    	{
	    		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO '{nickname}' (id_car, car, car_power) VALUES ('{car_uid}', '{car_name}', 280)");
	    		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO 'all cars set' VALUES ('{car_uid}', 'stock_crown_front_fender', 'stock_crown_back_fender', 'stock_crown_front_bumper', 'stock_crown_back_bumper', 'stock_crown_threshold')");
	     		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO 'car tech set' VALUES ('{car_uid}', '2', '2', '2', '2')");
	     	}
	    	break;
	    case "Wolga 24":
	    	if(CheckPrice(150))
	    	{
	    		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO '{nickname}' (id_car, car, car_power) VALUES ('{car_uid}', '{car_name}', 70)");
	    		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO 'all cars set' VALUES ('{car_uid}', 'wolga', 'wolga', 'wolga', 'wolga', 'wolga')");
	     		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO 'car tech set' VALUES ('{car_uid}', '2', '2', '2', '2')");
	     	}
	    	break;
	    case "Prius 20 cope":
	    	if(CheckPrice(500))
	    	{
	    		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO '{nickname}' (id_car, car, car_power) VALUES ('{car_uid}', '{car_name}', 76)");
	     		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO 'all cars set' VALUES ('{car_uid}', 'stock_prius20_cope_front_fender', 'stock_prius20_cope_back_fender', 'ralie_prius20_cope_front_bumper', 'stock_prius20_cope_back_bumper', 'stock_prius20_cope_threshold')");
	     		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO 'car tech set' VALUES ('{car_uid}', '2', '2', '2', '2')");
	     	}
	    	break;
	    case "Auris 2006":
	    	if(CheckPrice(200))
	    	{
	    		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO '{nickname}' (id_car, car, car_power) VALUES ('{car_uid}', '{car_name}', 76)");
	     		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO 'all cars set' VALUES ('{car_uid}', 'stock_auris_2006_front_fender', 'stock_auris_2006_back_fender', 'stock_auris_2006_front_bumper', 'stock_auris_2006_back_bumper', 'stock_auris_2006_threshold')");
	     		DataBase.ExecuteQueryWithoutAnswer(
					$"INSERT INTO 'car tech set' VALUES ('{car_uid}', '2', '2', '2', '2')");
	     	}
	    	break;
	}
    }

    void SetDropDown()
    {
        cars_name.ClearOptions();
        var part_list = new List<string>{};

        DataTable scoreboard = DataBase.GetTable($"SELECT car_model_name FROM 'all cars model'");

        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;

            part_list.Add(cells[0].ToString());
        }

        cars_name.AddOptions(part_list);

    }
}
