using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    [SerializeField] GameObject flashLight;    
    Light spotlight;
    [SerializeField] Light directlight;

    private void Start() {
        spotlight = flashLight.GetComponent<Light>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f")){
            if (spotlight.enabled == false){
                ToggleLightOn();
            }else{
                ToggleLightOff();
            }
        }

        if (Input.GetKeyDown("p")){
            if (spotlight.enabled == false){
                directlight.transform.Rotate(Vector3.up * 90);
            }
        }
          
    }

    void ToggleLightOff(){
        
        spotlight.enabled = false;
        
    }

    void ToggleLightOn(){
        
        spotlight.enabled = true;
        
    }
}
