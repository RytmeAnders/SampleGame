using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] powerUps;

    public float minTime;
    public float maxTime;
    public GameObject floor;

    private bool spawning;
    private float currentTime;
    private int currentPowerUp;
    private float floorX;
    private float floorZ;
    private float spawnX;
    private float spawnZ;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawnPowerUp");
        floorX = floor.transform.lossyScale.x / 2;
        floorZ = floor.transform.lossyScale.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnPowerUp()
    {
        while (true)
        {
            currentTime = Random.Range(minTime, maxTime); //Get a random time to spawn power ups
            currentPowerUp = (int)Random.Range(0, powerUps.Length-1); //Get a random index of the powerup array

            //The positions of the new power up (dependant on floor size)
            spawnX = Random.Range(-floorZ, floorX);
            spawnZ = Random.Range(-floorZ, floorZ);

            //Instantiate a power up within the size of the arena
            Instantiate(powerUps[currentPowerUp], new Vector3(spawnX, 1, spawnZ), Quaternion.identity);

            print("X: " + spawnX + ", Z: " + spawnZ);
            //print("Spawning!");
            //print("Power Up: " + currentPowerUp);
            //print("Curren Time: " + currentTime); //For debugging to see the current interval
            yield return new WaitForSeconds(currentTime);
        }

    }
}
