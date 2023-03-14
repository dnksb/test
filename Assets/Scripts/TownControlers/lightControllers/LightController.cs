using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    [SerializeField] private float speed_rotation;
    int interval = 1; 
    float nextTime = 0;
     
    void Update () {
        if (Time.time >= nextTime) {
             transform.Rotate(+speed_rotation, +speed_rotation, 0.0f);
             nextTime += interval; 
        } 
    }
}
