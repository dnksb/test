using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System;


enum PartsName
{
    Threshold, FrontFender, FrontBumper, BackFender, BackBumper
}

public class DropDownController : MonoBehaviour
{

    [SerializeField] private Dropdown choice_part;
    [SerializeField] private Dropdown parts;

    [SerializeField] private PartsName part_name;

    static public string car_model;

    [SerializeField] private int car_id;

    [SerializeField] private List<string> part_list;

    void Start()
    {
        part_name = PartsName.FrontBumper;
    }

    public void SetEnum()
    {
        switch (choice_part.value)
        {
            case 0:
                part_name = PartsName.FrontBumper;
                break;
            case 1:
                part_name = PartsName.BackBumper;
                break;
            case 2:
                part_name = PartsName.FrontFender;
                break;
            case 3:
                part_name = PartsName.BackFender;
                break;
            case 4:
                part_name = PartsName.Threshold;
                break;
        }
    }

    public void UpdateChoicePart()
    {
        DataTable scoreboard = DataBase.GetTable($"SELECT * FROM 'all cars model'");

        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;

            if(cells[1].ToString() == car_model)
            {
                car_id = Convert.ToInt32(cells[0].ToString());
                break;
            }
        }

        SetEnum();

        UpdatePartsDropdown();

    }

    public void UpdatePartsDropdown()
    {
        parts.ClearOptions();
        part_list = new List<string>{};

        DataTable scoreboard = DataBase.GetTable($"SELECT * FROM '{part_name}'");

        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;

            if(Convert.ToInt32(cells[0].ToString()) == car_id)
            {
                part_list.Add(cells[1].ToString());
            }
        }

        parts.AddOptions(part_list);
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
        var tmp1 = DataBase.ExecuteQueryWithAnswer($"UPDATE players SET level = {maney - price} WHERE nickname = '{ChoiceCarMenu.Nickname}'");
    	return true;
    }

    public void UpdateParts()
    {
        //Debug.Log("--------------");
        //Debug.Log($"{part_name}");
        //Debug.Log("--------------");
        //DataTable scoreboard = DataBase.GetTable($"UPDATE 'all cars set' SET '{part_name}' = '{part_list[parts.value]}' WHERE id_car = '{ChoiceCarMenu.id_car_text}'");
        //scoreboard.
        if(CheckPrice(10))
   	 {
   	     var tmp = DataBase.ExecuteQueryWithAnswer($"UPDATE 'all cars set' SET '{part_name}' = '{part_list[parts.value]}' WHERE id_car = '{ChoiceCarMenu.id_car_text}'");
        Debug.Log(tmp);
        }
        //ChoiceCarMenu.Updatecar();

    }
}
