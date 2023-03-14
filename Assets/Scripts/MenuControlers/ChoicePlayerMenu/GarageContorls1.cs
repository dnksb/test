using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarageContorls : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject visual;
    [SerializeField] private GameObject tech;

    public void PlayPressed()
    {
        SceneManager.LoadScene("Garage");
    }
    
    public void ExitPressed()
    {
        //SceneManager.Quit();
    }
    
    public void SettingsPressed()
    {
        menu.SetActive(false);
        tech.SetActive(false);
        visual.SetActive(false);
        settings.SetActive(true);
    }
    
    public void VisualPressed()
    {
        menu.SetActive(false);
        visual.SetActive(true);
        tech.SetActive(false);
        settings.SetActive(false);
    }
    
    public void TechPressed()
    {
        menu.SetActive(false);
        visual.SetActive(false);
        tech.SetActive(true);
        settings.SetActive(false);
    }    
}
