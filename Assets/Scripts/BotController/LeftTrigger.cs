using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTrigger : MonoBehaviour
{
    public bool IsTouch;

    void OnTriggerStay(Collider other) {
        IsTouch = true;
    }

    void OnTriggerExit(Collider other) {
        IsTouch = false;
    }
}
