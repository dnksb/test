using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIController : MonoBehaviour
{
    CarController ControlledCar;

	public int Counter = 100;

	public double Last;

	public float Horizontal;
	public float Vertical;
	public float MaxSpeed;
	public float BrakeCof;
	public bool trafic;

	public Transform COM;

	public Transform FrontLeft;
	public Transform FrontRight;
	public Transform FrontCenter;
	public Transform RareLeft;
	public Transform RareRight;

	public LeftTrigger left;
	public RightTrigger right;
	public CenterTrigger center;
	public BackTrigger back;

	public List<Transform> CheckPoint = new List<Transform>();
	public int CurrentCheckPoint = 0;

	public Vector3 StartPosition;
	public Quaternion StartRotation;

	public int CurrentAmountLaps;

	public void Start()
	{
		StartPosition = COM.transform.position;
		StartRotation = transform.rotation;
	}
	private void Awake ()
	{
		Last = Math.Floor((COM.transform.position - CheckPoint[CurrentCheckPoint].position).magnitude);
		ControlledCar = GetComponent<CarController> ();
		StartPosition = COM.transform.position;
		StartRotation = transform.rotation;
	}

	public void StartRace()
	{
		transform.position = StartPosition;
		transform.rotation = StartRotation;
		CurrentAmountLaps = 0;
		Last = Math.Floor((COM.transform.position - CheckPoint[CurrentCheckPoint].position).magnitude);
		ControlledCar = GetComponent<CarController> ();
	}

	void CheckBorders()
	{
		if (center.IsTouch && back.IsTouch)
			Vertical = 0.3f;
		else if (center.IsTouch)
			Vertical = -MaxSpeed;
		else if (back.IsTouch)
			Vertical = MaxSpeed;
		else
			Vertical = MaxSpeed;

		if (left.IsTouch && right.IsTouch)
			Horizontal = Horizontal;
		else if(left.IsTouch)
		{
			if(Horizontal != 0) Horizontal *= -0.8f;
			else if(Vertical > 0) Horizontal = 0.8f;
			else Horizontal = -0.8f;
			Vertical *= 0.8f;
		}
		else if(right.IsTouch)
		{
			if(Horizontal != 0) Horizontal *= -0.8f;
			else if(Vertical > 0) Horizontal = -0.8f;
			else Horizontal = 0.8f;
			Vertical *= 0.8f;
		}
		else
			Horizontal = Horizontal;
	}

	void CheckCheckPoints()
	{

		float front_center_distance = (FrontCenter.transform.position - CheckPoint[CurrentCheckPoint].position).magnitude;
		float front_left_distance = (FrontLeft.transform.position - CheckPoint[CurrentCheckPoint].position).magnitude;
		float front_right_distance = (FrontRight.transform.position - CheckPoint[CurrentCheckPoint].position).magnitude;
		float rare_left_distance = (RareLeft.transform.position - CheckPoint[CurrentCheckPoint].position).magnitude;
		float rare_right_distance = (RareRight.transform.position - CheckPoint[CurrentCheckPoint].position).magnitude;

		if (front_center_distance < front_left_distance &&
			front_center_distance < front_right_distance &&
			front_center_distance < rare_left_distance &&
			front_center_distance < rare_right_distance)
			{
				Horizontal = 0;
			}
		else if(front_left_distance < front_center_distance &&
			front_left_distance < front_right_distance &&
			front_left_distance < rare_left_distance &&
			front_left_distance < rare_right_distance)
			{
				Horizontal = -1;
				Vertical *= 0.6f;
			}
		else if(front_right_distance < front_center_distance &&
			front_right_distance < front_left_distance &&
			front_right_distance < rare_left_distance &&
			front_right_distance < rare_right_distance)
			{
				Horizontal = 1;
				Vertical *= 0.6f;
			}
		else if(rare_left_distance < front_center_distance &&
			rare_left_distance < front_left_distance &&
			rare_left_distance < front_right_distance &&
			rare_left_distance < rare_right_distance)
			{
				Horizontal = 1;
				Vertical *= -1;
			}
		else if(rare_right_distance < front_center_distance &&
			rare_right_distance < front_left_distance &&
			rare_right_distance < front_right_distance &&
			rare_right_distance < rare_left_distance)
			{
				Horizontal = -1;
				Vertical *= -1;
			}
	}

	void Update ()
	{
		Counter -= 1;
		if(Counter == 0)
		{
			if (Last == Math.Floor((COM.transform.position - CheckPoint[CurrentCheckPoint].position).magnitude))
				transform.position = CheckPoint[CurrentCheckPoint].position;
			Last = Math.Floor((COM.transform.position - CheckPoint[CurrentCheckPoint].position).magnitude);
			Counter = 100;
		}
		if((COM.transform.position - CheckPoint[CurrentCheckPoint].position).magnitude > 150)
			transform.position = CheckPoint[CurrentCheckPoint].position;
		if ((COM.transform.position - CheckPoint[CurrentCheckPoint].position).magnitude < 5)
			CurrentCheckPoint = MathExtentions.LoopClamp (CurrentCheckPoint + 1, 0, CheckPoint.Count);
		Vertical = MaxSpeed;
		CheckCheckPoints();
		if (!trafic) CheckBorders();
		if ((COM.transform.position - CheckPoint[CurrentCheckPoint].position).magnitude < 30) Vertical *= BrakeCof;
		ControlledCar.UpdateControls (Horizontal, Vertical, false);
	}
}
