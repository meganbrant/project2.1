using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public bool debug = false;

    public Rigidbody bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 50;


    public int totalAmmo = 30;
    public int clipSize = 10;
    public int clip = 0;


    public void Reload(){
      if(clip == clipSize){
        if(debug) Debug.Log("Clip is already full");
        return;
      }


      if(totalAmmo + clip >= clipSize){
        totalAmmo -= (clipSize - clip);
        clip = clipSize;
      } else{
        clip = totalAmmo +clip;
        totalAmmo = 0;
      }
    }



    public void Fire(){
     if(debug) Debug.Log("Pow");

     if(clip>0){
       clip-=1;
     Rigidbody bullet = Instantiate(bulletPrefab,bulletSpawn.position, bulletSpawn.rotation);
     bullet.transform.Translate(0,0,1);
     bullet.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
     } else{
       if(debug) Debug.Log("Out of Ammo");
     }
  }


  
}
