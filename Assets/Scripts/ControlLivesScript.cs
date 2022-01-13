using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlLivesScript : MonoBehaviour
{
    public Text livesNumberText;

    private void Awake()
    {
        StartCoroutine(freezeScreenAndUpdateLives());
    }

    private IEnumerator freezeScreenAndUpdateLives()
    {
        
        livesNumberText.text = PlayerStats.PlayerLives.ToString();
        yield return new WaitForSeconds(2f);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

}
