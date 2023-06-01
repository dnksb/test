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
    public GameObject Bouling;

    void Start()
    {
    	  GameObject UI = GameObject.Find("UI");
         Race1 = UI.transform.GetChild(2).gameObject;
         Race2 = UI.transform.GetChild(3).gameObject;
         Race3 = UI.transform.GetChild(4).gameObject;
         Race4 = UI.transform.GetChild(5).gameObject;
         Race5 = UI.transform.GetChild(6).gameObject;
         Bouling = UI.transform.GetChild(7).gameObject;
    }

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
        if(other.tag == "bouling")
        {
             Bouling.SetActive(true);
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
        if(other.tag == "bouling")
        {
             Bouling.SetActive(false);
        }
    }
}
