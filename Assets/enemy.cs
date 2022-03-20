using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform player;
    public float attackInterval = 2;
    public int attackDamage = 4;

    bool canAttack = true;
    Health playerHealth;


    // Start is called before the first frame update
    void Start() { 
        if(player == null) player = GameObject.Find("PlayerCapsule").transform;
        playerHealth = player.gameObject.GetComponent<Health>();
    
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, player.position)< 3) {
            if(canAttack){
                playerHealth.health -= attackDamage ;
                Debug.Log("Attack!");
                StartCoroutine(ResetAttack());
            }
        }
    }

    IEnumerator ResetAttack() {
        canAttack = false;
        yield return new WaitForSeconds(attackInterval);
        canAttack = true;
    }

}
