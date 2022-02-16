using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public GunScript gun; 
    public bool debug = false;

    

    void Update()
    {
        var mouse = Mouse.current;
        if(mouse ==null) return;

        if(mouse.leftButton.wasPressedThisFrame){
            if(debug) Debug.Log("Left Mouse buttons was pressed this frame.");
            
            if(gun != null){
                gun.Fire();
            }
        }

    var keyboard = Keyboard.current;
    if(keyboard== null) return;
    if(keyboard.rKey.wasPressedThisFrame) {
        if(gun != null){
            gun.Reload();
        }
    }


    }
}