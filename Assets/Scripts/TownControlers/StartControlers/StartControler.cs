using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartControler : MonoBehaviour
{
    [SerializeField] private GameObject car_model;
    [SerializeField] private SelectedCar selected_car;


    [SerializeField] static private string nickname;

    void Start()
    {
        //TownCarClass.SetCar(CarClass.GetSelectedCar);
        //nickname = CarClass.nickname;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
