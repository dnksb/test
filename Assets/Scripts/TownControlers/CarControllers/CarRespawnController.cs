using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRespawnController : MonoBehaviour
{

    public bool LapsMode;

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
                if(LapsMode)
                {
                    if(CurrentCheckPoint != 0)
                        transform.position = CheckPoint[CurrentCheckPoint - 1].position;
                    else
                        transform.position = CheckPoint[CheckPoint.Count - 1].position;
                }
                else
                {
                    transform.position = CheckPoint[CurrentCheckPoint - 1].position;
                }
            }
	    }
        if(RaceMode)
        {
            float distance = (COM.transform.position - CheckPoint[CurrentCheckPoint].position).magnitude;
            if(distance > 100 && RaceMode)
            {
                if(CurrentCheckPoint != 0)
                    transform.position = CheckPoint[CurrentCheckPoint - 1].position;
                else
                    transform.position = CheckPoint[CheckPoint.Count - 1].position;
            }
            if (distance < 8 && RaceMode)
                CurrentCheckPoint = MathExtentions.LoopClamp (CurrentCheckPoint + 1, 0, CheckPoint.Count);
        }
    }


}
