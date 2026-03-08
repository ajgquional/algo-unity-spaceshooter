/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Description: 
 *      Handles the collision between the collectible 
 *      game object and the Player.
 * 
 * How to use:
 *      - Attach the script to the collectible object
 *      - Ensure that the collectible object has a 
 *          Collider 2D component
 * **************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // checks if the collectible object collides specifically with the Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the Player collides with the collectible item, increment Player's points and destroy the item
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            player.points++;
            Destroy(this.gameObject);
        }
    }
}
