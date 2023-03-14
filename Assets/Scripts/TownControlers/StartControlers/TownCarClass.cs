using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownCarClass : MonoBehaviour
{
    [SerializeField] private static SelectedCar selected_car;
    [SerializeField] private SelectedCar town_car;
    [SerializeField] private GameObject template_car;
    [SerializeField] private GameObject show_car;

    public GameObject[] show_cars;
    void Start()
    {

        show_cars = GameObject.FindGameObjectsWithTag("play_car");
        /*Debug.Log("--------------");
        Debug.Log(show_cars.Length);
        Debug.Log("--------------");*/
        town_car.choiced_car = Instantiate(
            show_cars[0],
            template_car.transform) as GameObject;
        show_cars[0].SetActive(false);
        town_car.choiced_car.GetComponent<RectTransform>().SetParent(show_car.transform);
        if(town_car.choiced_car.name == "Porshe 911 turbo(Clone)(Clone)")
        {
        	town_car.choiced_car.transform.localScale = new Vector3(45.0f, 40.0f, 40.0f);
        	town_car.choiced_car.transform.rotation = Quaternion.Euler(-90, 0, 90);
        	town_car.choiced_car.transform.position = new Vector3(0, 0.5f, -1.454f);
        }
        else if(town_car.choiced_car.name == "Prius 20(Clone)(Clone)")
        {
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
        //town_car.choiced_car.transform.position += new Vector3(0, 0, 3.0f);
        town_car.choiced_car.SetActive(true);
    }

    /*public void InstantiateCar()
    {
        town_car.choiced_car = Instantiate(
            selected_car.choiced_car,
            template_car.transform) as GameObject;
        town_car.choiced_car.GetComponent<RectTransform>().SetParent(
            show_cars.transform);
        town_car.choiced_car.SetActive(true);
    }*/

    // Update is called once per frame
    void Update()
    {

    }
}
