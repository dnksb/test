using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHeadController : MonoBehaviour
{
    [SerializeField] KeyCode LeftKey;
    [SerializeField] KeyCode RightKey;
    [SerializeField] KeyCode UpKey;
    [SerializeField] KeyCode DownKey;
    [SerializeField] GameObject dulo;

    void Update()
    {
        if (Input.GetKey(LeftKey))
	    {
            transform.Rotate(0, -2, 0);
	    }
        if (Input.GetKey(RightKey))
	    {
            transform.Rotate(0, 2, 0);
	    }
        if (Input.GetKey(UpKey))
	    {
            if(dulo.transform.rotation.x > -0.205)
                dulo.transform.Rotate(-1, 0, 0);
	    }
        if (Input.GetKey(DownKey))
	    {
            if(dulo.transform.rotation.x < 0.07)
                dulo.transform.Rotate(1, 0, 0);
	    }
    }
}
