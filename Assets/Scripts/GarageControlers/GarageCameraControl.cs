using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageCameraControl : MonoBehaviour
{
    [SerializeField] private float speed_rotation;
    [SerializeField] private float speed_move;
    
    private bool garage_animation_rotation = false;

    private bool choice_car_animation_rotation = false;

    private bool visual_move_camera_animation = false;

    private bool back_menu_camera_animation = false;

    private void Start() 
    {
        transform.position = new Vector3(0, 0, 0);
        transform.Rotate(0, 0, 0);
        //Debug.Log(transform.rotation.y);
    }

    private void GarageAnimation()
    {
        if(garage_animation_rotation)
        {
            //Debug.Log(transform.rotation.y);
            if(transform.rotation.y >= 0.9999f)
            {
                garage_animation_rotation = false;
            }
            else
            {
                transform.Rotate(0.0f, +speed_rotation, 0.0f);
            }
        }
    }

    private void VisualSettingsAnimation()
    {
        if(visual_move_camera_animation)
        {
            //Debug.Log(transform.rotation.y);
            if(transform.position.z <= -300)
            {
                visual_move_camera_animation = false;
            }
            else
            {
                transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z - speed_move * Time.deltaTime);
            }
        }
    }

    private void ChoiceCarAnimation()
    {
        if(choice_car_animation_rotation)
        {
            //Debug.Log(transform.rotation.y);
            if(transform.rotation.y <= 0.001f)
            {
                choice_car_animation_rotation = false;
            }
            else
            {
                transform.Rotate(0.0f,-speed_rotation, 0.0f);
            }
        }
    }

    private void BackVisualSettingsAnimation()
    {
        if(back_menu_camera_animation)
        {
            //Debug.Log(transform.rotation.y);
            if(transform.position.z >= 0)
            {
                back_menu_camera_animation = false;
            }
            else
            {
                transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z + speed_move * Time.deltaTime);
            }
        }
    }

    private void Update() {

        GarageAnimation();
        ChoiceCarAnimation();
        VisualSettingsAnimation();
        BackVisualSettingsAnimation();
    }

    public void OpenGarage()
    {
        garage_animation_rotation = true;
        choice_car_animation_rotation = false;
        visual_move_camera_animation = false;
        back_menu_camera_animation = false;
    }

    public void OpenChoiceCar()
    {
        garage_animation_rotation = false;
        choice_car_animation_rotation = true;
        visual_move_camera_animation = false;
        back_menu_camera_animation = false;
    }
    
    public void OpenVisualSettings()
    {
        garage_animation_rotation = false;
        choice_car_animation_rotation = false;
        visual_move_camera_animation = true;
        back_menu_camera_animation = false;
    }

    public void CloseVisualSettings()
    {
        garage_animation_rotation = false;
        choice_car_animation_rotation = false;
        visual_move_camera_animation = false;
        back_menu_camera_animation = true;
    }
}
