/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Description: 
 *      Controls the operation of the player spaceship:
 *          - movement via mouse cursor or finger press
 *          - shooting projectiles
 * 
 * How to use:
 *      - Create the Player object
 *      - Setup the necessary sprite inside the Player 
 *          object
 *      - Make sure that the Player object has a Circle 
 *          Collider 2D component
 *      - Attach the script to the Player object
 * **************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int points;                      // points of the player

    public Projectile projectilePrefab;     // holder for the assigned projectile prefab

    public float shootInterval = 0.5f;      // delay between projectile shots
    public float shootTimer;                // start value of the timer (which would be updated)

    public Transform shootPoint;            // where the ship's projectile would start from

    // continuously move the ship (that is, check if the player is pressing the left mouse button)
    // also, automatically shoot projectiles from the ship
    void Update()
    {
        // calling the Move method to move the ship
        Move();

        // decrement shootTimer by the amount of time in between frames
        // then fire (clone) the projectile
        shootTimer -= Time.deltaTime;
        Shoot();
    }

    // method responsible for the Player's movement
    void Move()
    {
        // checks if there is a finger press/cursor click
        // move the Player if there is
        if (Input.GetMouseButton(0))
        {
            // gets cursor coordinates on the game screen
            Vector2 mousePos = Input.mousePosition;
            // translates the coordinates of a point from the coordinate plane of the screen to the global coordinate system of the scene
            // main property stores a reference to the active camera in the scene
            Vector2 realPos = Camera.main.ScreenToWorldPoint(mousePos);
            // assigns realPos as the position property of the transform component of the Player
            transform.position = realPos;
        }
    }

    void Shoot()
    {
        // clone the projectile if shootTimer goes below 0
        // projectile starts from the set shootPoint position in the ship
        // after cloning the projectile, re-assign the set shootInterval to shootTimer
        if (shootTimer <= 0)
        {
            Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            shootTimer = shootInterval;
        }
    }
}
