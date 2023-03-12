using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoiceCarMenu : MonoBehaviour
{

    [SerializeField] private GameObject menu;

    [SerializeField] private GameObject car;
    [SerializeField] private GameObject content;
    [SerializeField] private List<GameObject> clones;

    static public string id_car_text;

    public string car_model;

    private static string nickname;

    public CarClass selected_car;

    [SerializeField] private List<Material> materials;

    [SerializeField] private Dropdown choice_color;

    public static string Nickname
    {
        get{ return nickname; }
    }

    public void UpdateTable()
    {
        foreach (GameObject clon in clones)
        {
            Destroy(clon);
        }

        clones.Clear();

        Start();
    }

    //загрзка кнопок выбора машины
    private void Start()
    {

        clones = new List<GameObject>();
        /*nickname = ChoiceUserControler.GetPlayerNickname();
        DataTable scoreboard;
        try
        {
            scoreboard = DataBase.GetTable($"SELECT * FROM '{nickname}'");
        }
        catch
        {
            DataBase.ExecuteQueryWithoutAnswer($"CREATE TABLE'{nickname}' ('id_car' INTEGER NOT NULL, 'car' TEXT NOT NULL, 'car_power' INTEGER NOT NULL, PRIMARY KEY('id_car' AUTOINCREMENT))");
            scoreboard = DataBase.GetTable($"SELECT * FROM '{nickname}'");
        }
        Debug.Log(ChoiceUserControler.GetPlayerNickname());*/
        DataTable scoreboard = DataBase.GetTable($"SELECT * FROM 'Test'");
        nickname = "Test";

        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;

            clones.Add(Instantiate(car, car.transform));

            clones[clones.Count - 1].GetComponent<RectTransform>().SetParent(content.transform);
            clones[clones.Count - 1].SetActive(true);
            clones[clones.Count - 1].transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = $"Л/С: {cells[2].ToString()}";
            clones[clones.Count - 1].transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text = $"{cells[1].ToString()}";
            clones[clones.Count - 1].transform.GetChild(0).GetChild(3).gameObject.GetComponent<Text>().text = $"{cells[0].ToString()}";
        }
    }

    public void CloseGarage()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void ChoicecarId(GameObject id_car)
    {
        id_car_text = id_car.GetComponent<Text>().text;
    }

    public void Choicecar(GameObject text)
    {


        car_model = text.GetComponent<Text>().text;

        DropDownController.car_model = car_model;

        foreach (GameObject clon in clones)
        {
            if(clon.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text == car_model)
            {
                selected_car.ChoiceCar(car_model, id_car_text);
                //PlayerController.SetCar(selected_car);

            }
        }
    }

    public void Updatecar()
    {
        foreach (GameObject clon in clones)
        {
            if(clon.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text == car_model)
            {
                selected_car.ChoiceCar(car_model, id_car_text);
                UpdateChoiceColor();
                selected_car.ChangeCarColor(materials[0]);
            }
        }
    }

    public void UpdateChoiceColor()
    {
        selected_car.ChangeCarColor(materials[choice_color.value]);
    }

}
