/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Description: 
 *      Handles the collision between the obstacle 
 *      game object and the Player. Also includes an 
 *      animation and effect (visual and sound) when 
 *      the obstacle hits the Player. Moreover, the 
 *      size and rotation of the obstacles are 
 *      randomized to make the game more challenging.
 * 
 * How to use:
 *      - Attach the script to the obstacle object
 *      - Ensure that the obstacle object has a 
 *          Collider 2D component
 *      - Assign the player explosion effect asset 
 *          to the playerExplosionEffect field in the 
 *          Inspector
 * **************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // stores the chosen player explosion visual and sound effect
    public GameObject playerExplosionEffect;

    // specifying maximum and minimum size of the obstacle
    public float scaleMax = 1.3f;
    public float scaleMin = 0.7f;

    // specifying the maximum and minimum rotation of the obstacle
    public float rotationMax = 180f;
    public float rotationMin = 0f;

    // randomizes the size of the obstacle right away when the game starts
    private void Start()
    {
        randomSize();
    }

    // method to handle obstacle size randomization
    void randomSize()
    {
        // randomly chooses a scale factor (between the min and max values set) for the obstacle
        float scaleFactor = Random.Range(scaleMin, scaleMax);
        // then change the size of the obstacle relative to its parent according to the scale factor
        transform.localScale = (Vector2)transform.localScale * scaleFactor;

        // if the obstacle is needed to be decreased by a random number, the code below can be used:
        //transform.localScale = (Vector2)transform.localScale - new Vector2(scaleFactor, scaleFactor);
    }

    // method to handle obstacle rotation randomization
    void randomRotation()
    {
        // randomly chooses a rotation factor (between the min and max values set) for the obstacle
        float rotationFactor = Random.Range(rotationMin, rotationMax);
        // then change the rotation of the obstacle
        transform.localEulerAngles = Vector3.forward * rotationFactor;
    }

    // checks if the game object collides specifically with the Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the Player collides with an Obstacle, destroy the Player
        if (collision.tag == "Player")
        {
            // when the Obstacle is collided with by the Player, create an effect on the same position and rotation as the Obstacle
            // then destroy the effect after 5s
            GameObject playerExplosion = Instantiate(playerExplosionEffect, transform.position, transform.rotation);
            Destroy(playerExplosion, 5);

            Destroy(collision.gameObject);
        }
    }
}
