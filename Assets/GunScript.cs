using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    
    public Rigidbody bulletPrefab;
    public Transform bulletSpawn;

    [Range (10,100)]
    public float bulletSpeed = 50;
    public float fireRate = 0.1f;    

    public bool debug = false;

    [Header("Audio")]
    public AudioClip fire, clipUp, emptyAmmo;

    [Header("Ammo Manager")]
    public int totalAmmo = 30;
    public int clipSize = 10;
    public int clip = 0;

    private AudioSource aud;

    bool canShoot = true;

    void Start(){
      aud = this.gameObject.GetComponent<AudioSource>();

    }

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

        UIManager.ammoInClipText.text = "Clip: " + clip.ToString();
        UIManager.ammoInReserveText.text = "Ammo: " + totalAmmo.ToString();
    }

    public void Fire(){
      if(canShoot){
        if(debug) Debug.Log("Pow");
        if(clip>0){
          clip-=1;
          Rigidbody bullet = Instantiate(bulletPrefab,bulletSpawn.position, bulletSpawn.rotation);
          bullet.transform.Translate(0,0,1);
          bullet.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
          aud.PlayOneShot(fire);

          UIManager.ammoInClipText.text = "Clip: " + clip.ToString();
          StartCoroutine(Cooldown());
      } else{
          if(debug) Debug.Log("Out of Ammo");
          aud.PlayOneShot(emptyAmmo);
        }
      }
    }

    public void PickupAmmo(){
      totalAmmo += 90;
      UIManager.ammoInReserveText.text = "Ammo: " + totalAmmo.ToString();
      aud.PlayOneShot(clipUp);    
    }

    

    IEnumerator Cooldown(){
       canShoot = false;
       yield return new WaitForSeconds(fireRate);
       canShoot = true;
    }
  
    
    }

  

