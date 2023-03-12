using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerWithStartRace : MonoBehaviour
{

    public GameObject Race1;
    public GameObject Race2;
    public GameObject Race3;
    public GameObject Race4;
    public GameObject Race5;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Race1")
        {
             Race1.SetActive(true);
        }
        if(other.tag == "Race2")
        {
             Race2.SetActive(true);
        }
        if(other.tag == "Race3")
        {
             Race3.SetActive(true);
        }
        if(other.tag == "Race4")
        {
             Race4.SetActive(true);
        }
        if(other.tag == "Race5")
        {
             Race5.SetActive(true);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Race1")
        {
             Race1.SetActive(false);
        }
        if(other.tag == "Race2")
        {
             Race2.SetActive(false);
        }
        if(other.tag == "Race3")
        {
             Race3.SetActive(false);
        }
        if(other.tag == "Race4")
        {
             Race4.SetActive(false);
        }
        if(other.tag == "Race5")
        {
             Race5.SetActive(false);
        }
    }
}
