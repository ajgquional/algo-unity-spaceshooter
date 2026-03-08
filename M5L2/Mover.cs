/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Description: 
 *      Controls the operation of the obstacles (asteroid)
 *      and collectibles (star) in the game.
 * 
 * How to use:
 *      - Create the obstacle and colletible objects
 *      - Setup the necessary sprites
 *      - Attach the script to the both objects
 *      - Make a prefab out of the objects
 * **************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 2f;    // initial speed of the objects (can be modified via Inspector)

    // just destroys the game object 5s after starting the scene
    void Start()
    {
        // the game object which the script is attached to is deleted 5s after starting the scene
        // ensures that the game object would be destroyed when it goes out of the screen
        Destroy(gameObject, 5f);
    }

    // continuously move the objects down
    void Update()
    {
        transform.position = (Vector2)transform.position + Vector2.down * (speed + GameController.gameSpeed) * Time.deltaTime;
    }
}
