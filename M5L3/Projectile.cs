/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Description: 
 *      Implements the operation of the Player's projectile.
 *      Also includes an animation and effect (visual and 
 *      sound) when the obstacle is destroyed.
 * 
 * How to use:
 *      - Create a projectile object
 *      - Setup the necessary projectile sprite
 *      - Make sure that the projectile has a Collider 2D component
 *      - Attach the script to the projectile object
 *      - Assign the asteroid explosion effect asset to the 
 *          explosionEffect field in the Inspector
 * **************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;    // initial speed of the projectile

    // stores the chosen asteroid explosion visual and sound effect
    public GameObject explosionEffect;

    // just destroys the game object 1s after starting the scene
    void Start()
    {
        // the game object which the script is attached to is deleted 1s after starting the scene
        // ensures that the game object would be destroyed when it goes out of the screen
        Destroy(gameObject, 1f);
    }

    // continuously move the projectile up
    void Update()
    {
        transform.position = (Vector2)transform.position + Vector2.up * speed * Time.deltaTime;
    }

    // checks if the projectile collides specifically with an Obstacle
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the Projectile collides with an Obstacle, destroy both the Obstacle and the Projectile
        if (collision.tag == "Obstacle")
        {
            // when the Obstacle is collided with by the Projectile, create an effect on the same position and rotation as the Projectile
            // then destroy the effect after 5s
            GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(explosion, 5);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
