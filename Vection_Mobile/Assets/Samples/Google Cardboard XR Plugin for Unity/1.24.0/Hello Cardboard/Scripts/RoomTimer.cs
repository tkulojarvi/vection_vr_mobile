using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class RoomTimer : MonoBehaviour
{
    public float timeRemaining = 60; // Initial time in seconds

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Decrease timeRemaining by the time since last frame
            //Debug.Log(timeRemaining);
        }
        else
        {
            // Timer has reached 0, perform actions
            //Debug.Log("Timer has reached 0!");

            SceneManager.LoadScene("Main");

        }
    }
}
