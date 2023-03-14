using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;

    [SerializeField] private float speed_move;
    [SerializeField] private float speed_rotation;
    
    private bool garage_animation_forward = false;
    private bool garage_animation_rotation = false;

    private bool choice_user_animation_forward = false;
    private bool choice_user_animation_rotation = false;
    
    private bool main_menu_animation_forward = false;
    private bool main_menu_animation_rotation = false;

    private void Start() 
    {
        transform.position = new Vector3(552, 264, -1000);
        transform.Rotate(0,90,0);
    }

    private void GarageAnimation()
    {
        if(garage_animation_forward)
        {
            if(transform.position.z >= 2000.0f)
            {
                garage_animation_forward = false;
            }
            else
            {
                transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z + speed_move * Time.deltaTime);
            }
        }

        if(garage_animation_rotation)
        {
            //Debug.Log(transform.rotation.y);
            if(transform.rotation.y <= -0.7071068f)
            {
                garage_animation_rotation = false;
            }
            else
            {
                transform.Rotate(0.0f, -speed_rotation, 0.0f);
            }
        }
    }

    private void MenuAnimation()
    {
        if(main_menu_animation_forward)
        {
            if(transform.position.z <= -1000.0f)
            {
                main_menu_animation_forward = false;
            }
            else
            {
                transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z - speed_move * Time.deltaTime);
            }
        }

        if(main_menu_animation_rotation)
        {
            //Debug.Log(transform.rotation.y);
            if(transform.rotation.y >= 0f)
            {
                main_menu_animation_rotation = false;
            }
            else
            {
                transform.Rotate(0.0f, +speed_rotation, 0.0f);
            }
        }
    }

    private void ChoiceUserAnimation()
    {
        if(choice_user_animation_forward)
        {
            if(transform.position.z >= 2000.0f)
            {
                choice_user_animation_forward = false;
            }
            else
            {
                transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z + speed_move * Time.deltaTime);
            }
        }

        if(choice_user_animation_rotation)
        {
            //Debug.Log(transform.rotation.y);
            if(transform.rotation.y <= -0.7071068f)
            {
                choice_user_animation_rotation = false;
            }
            else
            {
                transform.Rotate(0.0f,-speed_rotation, 0.0f);
            }
        }
    }

    private void Update() {

        GarageAnimation();
        MenuAnimation();
        ChoiceUserAnimation();
    }

    public void OpenGrage()
    {
        garage_animation_forward = true;
        garage_animation_rotation = true;

        choice_user_animation_forward = false;
        choice_user_animation_rotation = false;
                
        main_menu_animation_forward = false;
        main_menu_animation_rotation = false;
    }

    public void OpenChoiceUser()
    {
        garage_animation_forward = false;
        garage_animation_rotation = false;

        choice_user_animation_forward = true;
        choice_user_animation_rotation = true;

        main_menu_animation_forward = false;
        main_menu_animation_rotation = false;
    }

    public void BackMenu()
    {
        garage_animation_forward = false;
        garage_animation_rotation = false;

        choice_user_animation_forward = false;
        choice_user_animation_rotation = false;

        main_menu_animation_forward = true;
        main_menu_animation_rotation = true;
    }
}