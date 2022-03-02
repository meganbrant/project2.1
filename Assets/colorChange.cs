using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour
{
    public Material originalMaterial;
    public Material changeMaterial;

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player") {
            transform.GetComponent<Renderer>().material = originalMaterial;
        }
    }

    void OnTriggerExit(Collider col){
        if (col.gameObject.tag == "Player") {
            transform.GetComponent<Renderer>().material = changeMaterial;
        }
    }

}

