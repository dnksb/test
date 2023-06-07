using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterTrigger : MonoBehaviour
{
    public bool IsTouch;

    void OnTriggerStay(Collider other) {
        if(other.tag != "CheckPoint") IsTouch = true;
    }

    void OnTriggerExit(Collider other) {
        IsTouch = false;
    }
}
