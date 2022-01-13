using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public GameObject settingsScreen;
    public GameObject infoScreen;
    public GameObject muteButton;
    public Sprite mutedAudio;
    public Sprite unmutedAudio;
    public AudioSource audioSource;
    private bool isInfoScreenActive = false;
    private bool isAudioMuted = false;

    public void muteAudio()
    {
        if (!isAudioMuted)
        {
            muteButton.GetComponent<Image>().sprite = mutedAudio;
            
            Settings.isSoundMuted = true;
            isAudioMuted = true;
        }
        else
        {
            muteButton.GetComponent<Image>().sprite = unmutedAudio;
            Settings.isSoundMuted = false;
            isAudioMuted = false;
        }
    }

    public void infoButton()
    {
        infoScreen.SetActive(true);
        isInfoScreenActive = true;
    }

    public void closeSettings()
    {
        settingsScreen.SetActive(false);
    }

    private void Update()
    {
        if (isInfoScreenActive == true)
            if (Input.anyKey)
            {
                infoScreen.SetActive(false);
                isInfoScreenActive = false;
            }
    }


}
