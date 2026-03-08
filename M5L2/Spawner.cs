/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Description: 
 *      Controls how selected game objects spawn in the game.
 * 
 * How to use:
 *      - Create a Spawner object then add left and right 
 *          border objects as its children
 *      - Attach the script to the Spawner object
 *      - Create a prefab of the Spawner object
 *      - Add an instance of the Spawner prefab in the 
 *          scene, for each of the objects to be spawned
 *      - Assign the object to be spawned and the spawn interval
 * **************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // object to be generated (can be set via the Inspector)
    public GameObject prefab;

    // boundaries of object generation
    public Transform borderRight;
    public Transform borderLeft;

    // spawn interval and a timer
    public float spawnInterval;
    public float spawnTimer;

    // continuously spawn the objects with a delay in between of the spawns
    void Update()
    {
        // decrements the spawn timer
        spawnTimer -= Time.deltaTime;

        // if spawnTimer goes below 0, spawn another object
        if (spawnTimer <= 0)
        {
            Spawn();
        }
    }

    // method to handle the actual spawn mechanic
    void Spawn()
    {
        // selects a random x-coordinate (within the set borders) where the object would spawn
        float randomX = Random.Range(borderLeft.position.x, borderRight.position.x);

        // assigns the random x-coordinate to the x-coordinate of the object
        Vector2 newPosition = transform.position;
        newPosition.x = randomX;

        // clones the object and puts in the assigned random x-coordinate
        Instantiate(prefab, newPosition, Quaternion.identity);
        // restarts the timer to the set spawn interval
        spawnTimer = spawnInterval;
    }
}
