using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// For user multiplatform control.
/// </summary>
[RequireComponent (typeof (CarController))]
public class UserControl :MonoBehaviour
{

	CarController ControlledCar;

	public float Horizontal;
	public float Vertical;
	public bool Brake;

	public static MobileControlUI CurrentUIControl { get; set; }

	private void Awake ()
	{
		ControlledCar = GetComponent<CarController> ();
		CurrentUIControl = FindObjectOfType<MobileControlUI> ();
	}

	void Update ()
	{
		if (CurrentUIControl != null && CurrentUIControl.ControlInUse)
		{
			//Mobile control.
			Horizontal = CurrentUIControl.GetHorizontalAxis;
			Vertical = CurrentUIControl.GetVerticalAxis;
		}
		else
		{
			//Standart input control (Keyboard or gamepad).
			Horizontal = Input.GetAxis ("Horizontal");
			Vertical = Input.GetAxis ("Vertical");
			Brake = Input.GetButton ("Jump");
		}

		//Apply control for controlled car.
		ControlledCar.UpdateControls (Horizontal, Vertical, Brake);
	}
}
