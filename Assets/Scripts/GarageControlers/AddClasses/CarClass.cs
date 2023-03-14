using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public struct CarsParts
{
    public List<GameObject> cars_body;
    public List<GameObject> cars_front_fender;
    public List<GameObject> cars_back_fender;
    public List<GameObject> cars_front_bumper;
    public List<GameObject> cars_back_bumper;
    public List<GameObject> cars_threshold;
}

public struct SelectedCar
{
    public GameObject choiced_car;
    public GameObject choiced_car_front_fender;
    public GameObject choiced_car_back_fender;
    public GameObject choiced_car_front_bumper;
    public GameObject choiced_car_back_bumper;
    public GameObject choiced_car_threshold;
}

public struct CarPartsName
{
    public string id_car;
    public string car_front_fender_name;
    public string car_back_fender_name;
    public string car_front_bumper_name;
    public string car_back_bumper_name;
    public string car_threshold_name;
    public string car_model_name;
}

//---------------------------------------------------------

public class CarClass : MonoBehaviour
{
    private CarsParts cars_parts;

    public List<GameObject> cars_body;
    public List<GameObject> cars_front_fender;
    public List<GameObject> cars_back_fender;
    public List<GameObject> cars_front_bumper;
    public List<GameObject> cars_back_bumper;
    public List<GameObject> cars_threshold;

    private CarPartsName car_parts_name;

    public static SelectedCar selected_car;

    [SerializeField] private GameObject template_car;
    [SerializeField] private GameObject show_cars;

    private static string nickname;

    // Start is called before the first frame update
    void Start()
    {
        nickname = ChoiceCarMenu.Nickname;
        cars_parts = new CarsParts();

        cars_parts.cars_body = cars_body;
        cars_parts.cars_front_fender = cars_front_fender;
        cars_parts.cars_back_fender = cars_back_fender;
        cars_parts.cars_front_bumper = cars_front_bumper;
        cars_parts.cars_back_bumper = cars_back_bumper;
        cars_parts.cars_threshold = cars_threshold;
    }

    public CarsParts GetCarsParts
    {
        get{ return this.cars_parts; }
    }

    public CarPartsName GetCarPartsName
    {
        get{ return this.car_parts_name; }
    }

    public static SelectedCar GetSelectedCar
    {
        get{ return selected_car; }
    }

        //поиск нужного корпуса в списке
    private int FindInCars(List<GameObject> parts, string part_name)
    {
        foreach (GameObject el in parts)
        {
            if(el.name == part_name)
            {
                return parts.IndexOf(el);
            }
        }
        return 0;
    }

    private GameObject GetPartInCars(List<GameObject> parts, string part_name)
    {
        return parts[FindInCars(parts, part_name)];
    }

    private GameObject InstantiatePartsInCar(GameObject selected, GameObject part)
    {
        selected = Instantiate(part,
            template_car.transform) as GameObject;
        selected.GetComponent<RectTransform>().SetParent(
            selected_car.choiced_car.transform);
        selected.SetActive(true);

        return selected;
    }

    private void AddPartsToCar()
    {
        Guid myuuid = Guid.NewGuid();
            string myuuidAsString = myuuid.ToString();

            //Debug.Log("Your UUID is: " + myuuidAsString);
        DataTable scoreboard = DataBase.GetTable($"SELECT * FROM 'all cars set'");

        foreach (DataRow row in scoreboard.Rows)
        {
            var cells = row.ItemArray;
            //Debug.Log(cells[0].ToString());
            if(cells[0].ToString() == car_parts_name.id_car)
            {
                car_parts_name.car_front_fender_name = cells[1].ToString();
                selected_car.choiced_car_front_fender = InstantiatePartsInCar(
                    selected_car.choiced_car_front_fender,
                    GetPartInCars(cars_parts.cars_front_fender, car_parts_name.car_front_fender_name));

                car_parts_name.car_back_fender_name = cells[2].ToString();
                selected_car.choiced_car_back_fender = InstantiatePartsInCar(
                    selected_car.choiced_car_back_fender,
                    GetPartInCars(cars_parts.cars_back_fender, car_parts_name.car_back_fender_name));

                car_parts_name.car_front_bumper_name = cells[3].ToString();
                selected_car.choiced_car_front_bumper = InstantiatePartsInCar(
                    selected_car.choiced_car_front_bumper,
                    GetPartInCars(cars_parts.cars_front_bumper, car_parts_name.car_front_bumper_name));

                car_parts_name.car_back_bumper_name = cells[4].ToString();
                selected_car.choiced_car_back_bumper = InstantiatePartsInCar(
                    selected_car.choiced_car_back_bumper,
                    GetPartInCars(cars_parts.cars_back_bumper, car_parts_name.car_back_bumper_name));

                car_parts_name.car_threshold_name = cells[5].ToString();
                selected_car.choiced_car_threshold = InstantiatePartsInCar(
                    selected_car.choiced_car_threshold,
                    GetPartInCars(cars_parts.cars_threshold, car_parts_name.car_threshold_name));
            }
        }
    }

    public void ChangeCarColor(Material material)
    {
        selected_car.choiced_car.GetComponent<Renderer>().material = material;
        selected_car.choiced_car_front_fender.GetComponent<Renderer>().material = material;
        selected_car.choiced_car_back_fender.GetComponent<Renderer>().material = material;
        selected_car.choiced_car_front_bumper.GetComponent<Renderer>().material = material;
        selected_car.choiced_car_back_bumper.GetComponent<Renderer>().material = material;
        selected_car.choiced_car_threshold.GetComponent<Renderer>().material = material;
    }

    public void ChoiceCar(string text, string id_car)
    {
        Destroy(selected_car.choiced_car);

        car_parts_name.car_model_name = text;
        car_parts_name.id_car = id_car;

        selected_car.choiced_car = Instantiate(
            GetPartInCars(cars_parts.cars_body, car_parts_name.car_model_name),
            template_car.transform) as GameObject;
        selected_car.choiced_car.GetComponent<RectTransform>().SetParent(
            show_cars.transform);
        selected_car.choiced_car.SetActive(true);

        AddPartsToCar();
    }
}
