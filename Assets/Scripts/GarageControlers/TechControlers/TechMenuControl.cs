using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TechMenuControl : MonoBehaviour
{

    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Visual_Settings;
    [SerializeField] private GameObject Tech_Settings;

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

    // Type in the name of the Scene you would like to load in the Inspector
    public string m_Scene;

    // Assign your GameObject you want to move Scene in the Inspector
    public GameObject m_MyGameObject;

    public void StartGame()
    {
    	foreach(GameObject elem in hidest_obj)
    	{
           elem.SetActive(false);
    	}
        m_MyGameObject.SetActive(false);

        //Scene currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);

        //SceneManager.MoveGameObjectToScene(m_MyGameObject, SceneManager.GetSceneByName(m_Scene));

        //SceneManager.UnloadSceneAsync(currentScene);
    }

}
