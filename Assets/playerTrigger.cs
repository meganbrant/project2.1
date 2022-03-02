using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTrigger : MonoBehaviour
{
    public GunScript gun;
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("ammo pickup")) {
            gun.GetAmmo();
        }
    }
}
