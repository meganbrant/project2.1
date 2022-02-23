using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public bool debug = false;

    public Rigidbody bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 50;
    public float fireRate = 0.1f;

    public int totalAmmo = 30;
    public int clipSize = 10;
    public int clip = 0;

    bool canShoot = true;

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
      if(canShoot){
        if(debug) Debug.Log("Pow");
        if(clip>0){
          clip-=1;
          Rigidbody bullet = Instantiate(bulletPrefab,bulletSpawn.position, bulletSpawn.rotation);
          bullet.transform.Translate(0,0,1);
          bullet.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);

          StartCoroutine(Cooldown());
      } else{
          if(debug) Debug.Log("Out of Ammo");
      }

      }
    }
      IEnumerator Cooldown(){
       canShoot = false;
       yield return new WaitForSeconds(fireRate);
       canShoot = true;
     }
  


  
}
