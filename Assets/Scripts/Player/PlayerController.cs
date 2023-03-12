using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static public SelectedCar selected_car;

    public void SetCar(CarClass car)
    {
        //selected_car = car.GetSelectedCar;
        Debug.Log("-------------");
        Debug.Log("set car");
        Debug.Log("-------------");
    }
}
