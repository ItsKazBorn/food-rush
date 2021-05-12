using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPointsOven;
    public GameObject[] ovenEnemies;

    public GameObject[] spawnPointsFryer;
    public GameObject[] fryerEnemies;
    
    public float spawnTimeOven = 5;
    public float spawnTimeFryer = 15;
    
    private float startDelay = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomOvenEnemy", startDelay, spawnTimeOven);
        InvokeRepeating("SpawnRandomFryerEnemy", startDelay, spawnTimeFryer);
        
        // CancelInvoke Stops ALL invoke repeatings in class
        //CancelInvoke();
    }
    
    void SpawnRandomOvenEnemy()
    {
        int randomPoint = Random.Range(0, spawnPointsOven.Length);
        int randomEnemy = Random.Range(0, ovenEnemies.Length);
        Vector3 randomPosition = spawnPointsOven[randomPoint].transform.position;

        Instantiate(ovenEnemies[randomEnemy], randomPosition, ovenEnemies[randomEnemy].transform.rotation);
        
    }

    void SpawnRandomFryerEnemy()
    {
        int randomPoint = Random.Range(0, spawnPointsFryer.Length);
        int randomEnemy = Random.Range(0, fryerEnemies.Length);
        Vector3 randomPosition = spawnPointsFryer[randomPoint].transform.position;

        Instantiate(fryerEnemies[randomEnemy], randomPosition, fryerEnemies[randomEnemy].transform.rotation);
    }
}
