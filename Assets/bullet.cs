using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
   public int damage = 2;

   void Start() {
      if(Random.value < .8f) {
         damage *= 2;
      }
   }


}
