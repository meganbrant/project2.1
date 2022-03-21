using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    
    public GameObject enemyPrefab;
    public Transform player;
    public int totalDesiredEnemies = 10;
    public float spawnInterval = 4;

    int enemiesCreated = 0;

    
    void Start() {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        while(enemiesCreated < totalDesiredEnemies) {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }


    void SpawnEnemy() {
        GameObject enemy = Instantiate(enemyPrefab.gameObject, this.transform.position, this.transform.rotation);
        enemy.transform.Translate(0, 1, 0);
        
    }

    //Anytime I replace the GameObject with Enemy my unity freaks out and its like "are you sure" so Im very confused
    //I followed everything you did five times over idk


}
