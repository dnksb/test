using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContorls : MonoBehaviour
{
    [SerializeField] private GameObject main_menu;
    [SerializeField] private GameObject settings;

    public void PlayPressed()
    {
        SceneManager.LoadScene("Garage");
    }
    
    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
    
    public void SettingsPressed()
    {
        main_menu.SetActive(false);
        settings.SetActive(true);
    }
}
