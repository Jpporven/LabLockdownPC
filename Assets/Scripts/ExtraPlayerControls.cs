using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPlayerController : MonoBehaviour
{
    private bool isPaused = false;
    private bool isNotebookOpen = false;
    private bool isGrabbing = false;

    // Update is called once per frame
    void Update()
    {
        // Pause game
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (!isPaused)
            {
                Time.timeScale = 0f;
                isPaused = true;
            }
            else
            {
                Time.timeScale = 1f;
                isPaused = false;
            }
        }

        // Open/close notebook
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isNotebookOpen)
            {
                // Code to open notebook
                Debug.Log("Notebook opened.");
                isNotebookOpen = true;
            }
            else
            {
                // Code to close notebook
                Debug.Log("Notebook closed.");
                isNotebookOpen = false;
            }
        }

        // Grab/let go of object
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isGrabbing)
            {
                // Code to grab object
                Debug.Log("Grabbed object.");
                isGrabbing = true;
            }
            else
            {
                // Code to let go of object
                Debug.Log("Let go of object.");
                isGrabbing = false;
            }
        }
    }
}