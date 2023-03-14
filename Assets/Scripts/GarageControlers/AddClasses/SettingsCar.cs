using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Data;
using System;

public class SettingsCar : MonoBehaviour
{
    [SerializeField] static private float car_back_slide;
    [SerializeField] static private float car_front_slide;

    [SerializeField] static private float front_car_side_slide;
    [SerializeField] static private float front_car_front_slide;

    [SerializeField] static private float back_car_side_slide;
    [SerializeField] static private float back_car_front_slide;

    [SerializeField] private Scrollbar scrol_bar_side;
    [SerializeField] private Scrollbar scrol_bar_front;

    public string id_car_text;

    public void Start()
    {
        car_back_slide = 2;
        car_front_slide = 2;

        front_car_front_slide = car_front_slide;
        front_car_side_slide = 4.0f - front_car_front_slide;

        back_car_front_slide = car_back_slide;
        back_car_side_slide = 4.0f - back_car_front_slide;

    }

    static public float FrontCarSideSlide
    {
        get{return front_car_side_slide;}
    }

    static public float FrontCarFrontSlide
    {
        get{return front_car_front_slide;}
    }

    static public float BackCarSideSlide
    {
        get{return back_car_side_slide;}
    }

    static public float BackCarFrontSlide
    {
        get{return back_car_front_slide;}
    }

    public void SideSlider()
    {
        car_back_slide = scrol_bar_side.value * 4.0f;
        back_car_front_slide = car_back_slide;
        back_car_side_slide = 4.0f - back_car_front_slide;
    }

    public void FrontSlider()
    {
        car_front_slide = scrol_bar_front.value * 4.0f;
        front_car_front_slide = car_front_slide;
        front_car_side_slide = 4.0f - front_car_front_slide;
    }
    
    public void SetForRace()
    {
        front_car_front_slide = 2.5f;
        front_car_side_slide = 0.7f;

        back_car_front_slide = 2.5f;
        back_car_side_slide = 0.7f;
    }
    
    public void SetForDrift()
    {
        front_car_front_slide = 2.22f;
        front_car_side_slide = 2.22f;

        back_car_front_slide = 2.6f;
        back_car_side_slide = 0.7f;
    }

    public void SetFromBD(GameObject id_car)
    {
        id_car_text = id_car.GetComponent<Text>().text;

        DataTable scoreboard = DataBase.GetTable($"SELECT * FROM 'car tech set'");

        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;

            if(id_car_text == cells[0].ToString())
            {
                front_car_front_slide = (float) Convert.ToDouble(cells[1].ToString());
                front_car_side_slide = (float) Convert.ToDouble(cells[2].ToString());
                back_car_front_slide = (float) Convert.ToDouble(cells[3].ToString());
                back_car_side_slide = (float) Convert.ToDouble(cells[4].ToString());
            }
        }
    }

    public void SaveToDB()
    {
        DataBase.ExecuteQueryWithoutAnswer($"UPDATE 'car tech set' SET front_front =  '{front_car_front_slide}', front_side = '{front_car_side_slide}', back_front = '{back_car_front_slide}', back_side = '{back_car_side_slide}' WHERE car_id = '{id_car_text}'");
    }

}
