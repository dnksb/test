using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AprroveController : MonoBehaviour
{
	[SerializeField] private GameObject visual;
	[SerializeField] private GameObject tech;
	
	public void ShowVisual()
	{
		visual.SetActive(true);
	}
	
	public void TechVisual()
	{
		tech.SetActive(true);
	}
	
	public void HideAll()
	{
		tech.SetActive(false);	
		visual.SetActive(false);
	}
}
