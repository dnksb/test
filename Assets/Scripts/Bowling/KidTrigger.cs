using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidTrigger : MonoBehaviour
{
    public bool IsBroke;
    public Vector3 Position;

    public void Awake()
    {
        Position = transform.position;
    }

    public void StartBouling()
    {
        IsBroke = false;
        transform.position = Position;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car")
        {
            IsBroke = true;
        }
    }
}
