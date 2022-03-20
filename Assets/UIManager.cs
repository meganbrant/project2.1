using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    public static TextMeshProUGUI playerHealthText;

   // static int totalEnemiesKilled = 0; 
     
    void Awake() {
        playerHealthText = GameObject.Find("PlayerHealthText").GetComponent<TextMeshProUGUI>();
        /*enemiesKilledText = GameObject.Find("EnemiesKilledText").GetComponent<TextMeshProUGUI>();
        ammoInClipText = GameObject.Find("AmmoInClipText").GetComponent<TextMeshProUGUI>();
        ammoInReserveText = GameObject.Find("AmmoInReserveText").GetComponent<TextMeshProUGUI>();
    */
    }

    /*public static void KilledEnemy() {
        totalEnemiesKilled += 1;
        enemiesKilledText.text = "Kill Count: " + totalEnemiesKilled.ToString();
    }*/
}

