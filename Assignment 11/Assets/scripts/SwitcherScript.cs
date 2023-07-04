using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SwitcherScript : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera thirdP;
    [SerializeField] CinemachineVirtualCamera firstP;
    [SerializeField] Light spotLight;
    [SerializeField] Light directionalLight;
    //post processes
    [SerializeField] Volume pp1;
    [SerializeField] Volume pp2;
    [SerializeField] Volume pp3;
    [SerializeField] Volume pp4;
    [SerializeField] Volume pp5;

    void Start()
    {
    }

    private void OnEnable()
    {
        CameraSwitch.Register(thirdP);
        CameraSwitch.Register(firstP);
        CameraSwitch.SwitchCamera(thirdP);
    }
    private void OnDisable()
    {
        CameraSwitch.Unregister(thirdP);
        CameraSwitch.Unregister(firstP);
    }

    public void Update()
    {
        if (Input.GetKeyDown("1")) 
        {
            if (CameraSwitch.IsActiveCamera(thirdP))
            {
                CameraSwitch.SwitchCamera(firstP);
                
                spotLight.enabled = false;
                directionalLight.enabled = true;
                PP_ON();
            }
        }

        if (Input.GetKeyDown("2")) 
        {
            if (CameraSwitch.IsActiveCamera(firstP))
            {
                CameraSwitch.SwitchCamera(thirdP);
                spotLight.enabled = true;
                directionalLight.enabled = false;
                PP_Off();
            }

            
        }
        CameraZoom();
    }


    void CameraZoom(){
        if (Input.GetKeyDown("8")){
            // Debug.Log("meh");
            thirdP.m_Lens.FieldOfView = 40f;
        }

        if (Input.GetKeyDown("9")){
            // Debug.Log("meh");
            thirdP.m_Lens.FieldOfView = 50f;
        }
        if (Input.GetKeyDown("0")){
            // Debug.Log("meh");
            thirdP.m_Lens.FieldOfView = 60f;
        }
    }

    void PP_Off(){
        pp1.enabled = false;
        pp2.enabled = false;
        pp3.enabled = false;
        pp4.enabled = false;
        pp5.enabled = false;
    }


    void PP_ON(){
        pp1.enabled = true;
        pp2.enabled = true;
        pp3.enabled = true;
        pp4.enabled = true;
        pp5.enabled = true;
    }

    

}
