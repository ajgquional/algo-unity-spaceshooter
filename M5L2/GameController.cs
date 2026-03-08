/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Description: 
 *      Controls the difficulty of the game, maintains 
 *      in-game statistics, manages the spawning
 *      of obstacles, and does probability calculations.
 * 
 * How to use:
 *      - Create a Game Controller object
 *      - Attach the script to the Game Controller object
 * **************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // speed of the game is the same for all objects
    public static float gameSpeed;

    // for gameSpeed to be variable in the Inspector Window via a slider
    [Range(0, 5)]
    public float gameSpeedRegulator;
    // for gameSpeed to not increase dramatically
    public float speedRate = 0.5f;
    // maximum speed for the game
    public float gameSpeedMax = 5;

    // continuously increase game speed as long as it doesn't exceed the set maximum speed
    void Update()
    {
        if (gameSpeedRegulator <= gameSpeedMax)
        {
            // increasing the gameSpeed as long as it's not yet exceeding the maximum
            gameSpeedRegulator += speedRate * Time.deltaTime;
        }

        // continuously assign the computed speed regulator to the game speed
        gameSpeed = gameSpeedRegulator;
    }
}
