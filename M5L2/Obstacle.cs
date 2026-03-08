/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Description: 
 *      Handles the collision between the obstacle 
 *      game object and the Player.
 * 
 * How to use:
 *      - Attach the script to the obstacle object
 *      - Ensure that the obstacle object has a 
 *          Collider 2D component
 * **************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // checks if the game object collides specifically with the Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the Player collides with an Obstacle, destroy the Player
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
