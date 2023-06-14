using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class TechMenuControl : MonoBehaviour
{

    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Visual_Settings;
    [SerializeField] private GameObject Tech_Settings;
    [SerializeField] private GameObject Loading;
    [SerializeField] private GameObject Camera;
    [SerializeField] private VideoPlayer Video;

    [SerializeField] private GameObject selected_car;
    [SerializeField] private List<GameObject> hidest_obj;

    public void ShowVusialSettings()
    {
        Menu.SetActive(false);
        Visual_Settings.SetActive(true);
    }

    public void CloseVusialSettings()
    {
        Menu.SetActive(true);
        Visual_Settings.SetActive(false);
    }

    public void ShowTechSettings()
    {
        Menu.SetActive(false);
        Tech_Settings.SetActive(true);
    }

    public void CloseTechSettings()
    {
        Menu.SetActive(true);
        Tech_Settings.SetActive(false);
    }

    public void Start()
    {
        Loading.SetActive(false);
        Camera.SetActive(true);
    }

    // Type in the name of the Scene you would like to load in the Inspector
    public string m_Scene;

    // Assign your GameObject you want to move Scene in the Inspector
    public GameObject m_MyGameObject;
    private static AsyncOperation syncLevel;
    public void StartVideo()
    {
        Loading.SetActive(true);
        Video.Play();
        foreach(GameObject elem in hidest_obj)
            elem.SetActive(false);
        m_MyGameObject.SetActive(false);
    }

    public void StartGame()
    {
        syncLevel = SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);
    }

    public void Update()
    {
        if(syncLevel.isDone)
        {
            Loading.SetActive(false);
            Camera.SetActive(false);
        }
    }
}
