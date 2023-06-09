using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRespawnController : MonoBehaviour
{

    [SerializeField] KeyCode SetCameraKey;
    [SerializeField] GameObject car;
    public Transform COM;

    public bool RaceMode;

    public List<Transform> CheckPoint = new List<Transform>();
	public int CurrentCheckPoint = 0;

    public int CurrentAmountLaps;

    public void Start()
    {
        RaceMode = false;
        CurrentCheckPoint = 0;
    }

    public void StartRace(List<Transform> list)
    {
        RaceMode = true;
        CheckPoint = list;
        CurrentCheckPoint = 0;
        CurrentAmountLaps = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (SetCameraKey))
	    {
            if(!RaceMode)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.position = new Vector3(-146.9f, 2, -86.5f);
            }
            else
            {
                transform.position = CheckPoint[CurrentCheckPoint].position;
            }
	    }
        if((COM.transform.position - CheckPoint[CurrentCheckPoint].position).magnitude > 150 && RaceMode)
			transform.position = CheckPoint[CurrentCheckPoint].position;
        if ((COM.transform.position - CheckPoint[CurrentCheckPoint].position).magnitude < 5 && RaceMode)
			CurrentCheckPoint = MathExtentions.LoopClamp (CurrentCheckPoint + 1, 0, CheckPoint.Count);
    }


}
