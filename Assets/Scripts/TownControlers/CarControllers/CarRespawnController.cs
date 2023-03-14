using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRespawnController : MonoBehaviour
{

    [SerializeField] KeyCode SetCameraKey; 
    [SerializeField] GameObject car;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (SetCameraKey))
	{
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = new Vector3(-146.9f, 2, -86.5f);
	}
    }
}
