using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidTrigger : MonoBehaviour
{
    public bool IsBroke;
    public Vector3 Position;
    public Quaternion StartRotation;

    public void Awake()
    {
        Position = transform.position;
        StartRotation = transform.rotation;
    }

    public void StartBouling()
    {
        IsBroke = false;
        transform.position = Position;
        transform.rotation = StartRotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car")
        {
            IsBroke = true;
        }
    }
}
