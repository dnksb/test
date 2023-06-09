﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class game controller.
/// </summary>
public class GameController :MonoBehaviour
{
	[SerializeField] KeyCode NextCarKey = KeyCode.N;
	[SerializeField] UnityEngine.UI.Button NextCarButton;
	public static GameController Instance;
	public static CarController PlayerCar { get { return Instance.m_PlayerCar; } }
	public static bool RaceIsStarted { get { return true; } }
	public static bool RaceIsEnded { get { return false; } }

	public CarController m_PlayerCar;
	public List<CarController> Cars = new List<CarController>();
	public int CurrentCarIndex = 0;

	public void UpdateList()
	{
		Instance = this;
		Cars.Clear();
		//Find all cars in current game.
		Cars.AddRange (GameObject.FindObjectsOfType<CarController> ());
		Cars.RemoveAll(c => c.tag == "Bot");
		Cars = Cars.OrderBy (c => c.name).ToList();
	}

	protected virtual void Awake ()
	{

		Instance = this;

		//Find all cars in current game.
		Cars.AddRange (GameObject.FindObjectsOfType<CarController> ());
		Cars.RemoveAll(c => c.tag == "Bot");
		Cars = Cars.OrderBy (c => c.name).ToList();

		foreach (var car in Cars)
		{
			var userControl = car.GetComponent<UserControl>();
			var audioListener = car.GetComponent<AudioListener>();

			if (userControl == null)
			{
				userControl = car.gameObject.AddComponent<UserControl> ();
			}

			if (audioListener == null)
			{
				audioListener = car.gameObject.AddComponent<AudioListener> ();
			}

			userControl.enabled = false;
			audioListener.enabled = false;
		}

		m_PlayerCar = Cars[0];
		m_PlayerCar.GetComponent<UserControl> ().enabled = true;
		m_PlayerCar.GetComponent<AudioListener> ().enabled = true;
		m_PlayerCar.GetComponent<CarRespawnController> ().enabled = true;

		if (NextCarButton)
        	{
			NextCarButton.onClick.AddListener (NextCar);
		}
	}

	void Update ()
	{
		if (Input.GetKeyDown (NextCarKey))
		{
			NextCar ();
		}

	}

	private void NextCar ()
	{
		m_PlayerCar.GetComponent<UserControl> ().enabled = false;
		m_PlayerCar.GetComponent<AudioListener> ().enabled = false;
		m_PlayerCar.GetComponent<CarRespawnController> ().enabled = false;

		CurrentCarIndex = MathExtentions.LoopClamp (CurrentCarIndex + 1, 0, Cars.Count);

		m_PlayerCar = Cars[CurrentCarIndex];
		m_PlayerCar.GetComponent<UserControl> ().enabled = true;
		m_PlayerCar.GetComponent<AudioListener> ().enabled = true;
		m_PlayerCar.GetComponent<CarRespawnController> ().enabled = true;
		m_PlayerCar.GetComponent<CarController> ().enabled = true;
	}
}
