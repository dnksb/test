using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAllWheels : MonoBehaviour
{
    [SerializeField] static private float front_car_side_slide;
    [SerializeField] static private float front_car_front_slide;

    [SerializeField] static private float back_car_side_slide;
    [SerializeField] static private float back_car_front_slide;

    [SerializeField] private GameObject front_wheel_r;
    [SerializeField] private GameObject front_wheel_l;
    [SerializeField] private GameObject back_wheel_r;
    [SerializeField] private GameObject back_wheel_l;

    void Start()
    {
        front_car_side_slide = SettingsCar.FrontCarSideSlide;
        front_car_front_slide = SettingsCar.FrontCarFrontSlide;

        back_car_side_slide = SettingsCar.BackCarSideSlide;
        back_car_front_slide = SettingsCar.BackCarFrontSlide;

	    SetWheels();
    }

    public void SetWheels()
    {
	WheelFrictionCurve wfc = front_wheel_r.GetComponent<WheelCollider>().sidewaysFriction;
	wfc.extremumValue = front_car_front_slide;
	wfc.asymptoteValue = front_car_front_slide;
	front_wheel_r.GetComponent<WheelCollider>().forwardFriction = wfc;
	front_wheel_l.GetComponent<WheelCollider>().forwardFriction = wfc;
	wfc.extremumValue = front_car_side_slide;
	wfc.asymptoteValue = front_car_side_slide;
	front_wheel_r.GetComponent<WheelCollider>().sidewaysFriction = wfc;
	front_wheel_l.GetComponent<WheelCollider>().sidewaysFriction = wfc;

	wfc = back_wheel_r.GetComponent<WheelCollider>().sidewaysFriction;
	wfc.extremumValue = back_car_front_slide;
	wfc.asymptoteValue = back_car_front_slide;
	back_wheel_r.GetComponent<WheelCollider>().forwardFriction = wfc;
	back_wheel_l.GetComponent<WheelCollider>().forwardFriction = wfc;
	wfc.extremumValue = back_car_side_slide;
	wfc.asymptoteValue = back_car_side_slide;
	back_wheel_r.GetComponent<WheelCollider>().sidewaysFriction = wfc;
	back_wheel_l.GetComponent<WheelCollider>().sidewaysFriction = wfc;
    }
}
