using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuInteractions : MonoBehaviour
{

    public GameObject settingsPanel;
    public AudioSource backgroundMusic;

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void openSettings()
    {
        Time.timeScale = 0f;
        settingsPanel.SetActive(true);
        
    }

    public void exitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        backgroundMusic.mute = Settings.isSoundMuted;
    }



}
