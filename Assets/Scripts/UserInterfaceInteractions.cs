using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterfaceInteractions : MonoBehaviour
{

    public GameObject exitPanel;
    public GameObject pausePanel;
    private bool isPaused = false;


    public void pauseGame()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (isPaused)
            if (Input.anyKey)
                resumeGame();
    }

    public void exitGame()
    {
        exitPanel.SetActive(true);
        Time.timeScale = 0f;
    }

}
