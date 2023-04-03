using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownCarClass : MonoBehaviour
{
    [SerializeField] private static SelectedCar selected_car;
    [SerializeField] private SelectedCar town_car;
    [SerializeField] private GameObject template_car;
    [SerializeField] private GameObject show_car;
    [SerializeField] private GameObject back_wheel_1;
    [SerializeField] private GameObject back_wheel_2;
    [SerializeField] private CarController wheels;

    public GameObject[] show_cars;
    void Start()
    {

        show_cars = GameObject.FindGameObjectsWithTag("play_car");
        /*Debug.Log("--------------");*/
        town_car.choiced_car = Instantiate(
            show_cars[0],
            template_car.transform) as GameObject;
        show_cars[0].SetActive(false);
        town_car.choiced_car.GetComponent<RectTransform>().SetParent(show_car.transform);
        wheels.Drivetype = DriveType.RWD;
        back_wheel_1.transform.position = new Vector3(0.8f, 0.27f, 1.215f);
        back_wheel_2.transform.position = new Vector3(-0.8f, 0.27f, 1.215f);
        if(town_car.choiced_car.name == "Porshe 911 turbo(Clone)(Clone)")
        {
        	town_car.choiced_car.transform.localScale = new Vector3(45.0f, 40.0f, 40.0f);
        	town_car.choiced_car.transform.rotation = Quaternion.Euler(-90, 0, 90);
        	town_car.choiced_car.transform.position = new Vector3(0, 0.5f, -1.454f);
        }
        else if(town_car.choiced_car.name == "Prius 20(Clone)(Clone)")
        {
        	wheels.Drivetype = DriveType.FWD;
        	town_car.choiced_car.transform.localScale = new Vector3(45.0f, 40.0f, 40.0f);
        	town_car.choiced_car.transform.rotation = Quaternion.Euler(-90, 0, 90);
        	town_car.choiced_car.transform.position = new Vector3(0, 0.4f, -1.454f);
        }
        else if(town_car.choiced_car.name == "Crown 1985(Clone)(Clone)")
        {
        	town_car.choiced_car.transform.localScale = new Vector3(151.7f, 134.8f, 134.8f);
        	town_car.choiced_car.transform.rotation = Quaternion.Euler(-90, 0, 90);
        	town_car.choiced_car.transform.position = new Vector3(0, 0.64f, -0.49f);
        }
        else if(town_car.choiced_car.name == "Wolga 24(Clone)(Clone)")
        {
        	town_car.choiced_car.transform.localScale = new Vector3(98.18f, 98.18f, 98.18f);
        	town_car.choiced_car.transform.rotation = Quaternion.Euler(180, 0, -180);
        	town_car.choiced_car.transform.position = new Vector3(0, 0.02f, 0.1f);
        }
        else if(town_car.choiced_car.name == "Prius 20 cope(Clone)(Clone)")
        {
		back_wheel_1.transform.position = new Vector3(0.85f, 0.27f, 0.29f);
		back_wheel_2.transform.position = new Vector3(-0.85f, 0.27f, 0.29f);
		town_car.choiced_car.transform.localScale = new Vector3(44.9f, 44.9f, 44.9f);
		town_car.choiced_car.transform.rotation = Quaternion.Euler(-90, 0, 90);
		town_car.choiced_car.transform.position = new Vector3(0, 0.43f, -1.40f);
		wheels.Drivetype = DriveType.AWD;
        }
        else if(town_car.choiced_car.name == "Auris 2006(Clone)(Clone)")
        {
        	back_wheel_1.transform.position = new Vector3(0.8f, 0.27f, 0.823f);
		back_wheel_2.transform.position = new Vector3(-0.8f, 0.27f, 0.823f);
        	wheels.Drivetype = DriveType.FWD;
        	town_car.choiced_car.transform.localScale = new Vector3(153.1f, 136.0889f, 136.0889f);
        	town_car.choiced_car.transform.rotation = Quaternion.Euler(0, 0, 0);
        	town_car.choiced_car.transform.position = new Vector3(0, 0.112f, -1.258f);
        }
        town_car.choiced_car.SetActive(true);
    }
}
