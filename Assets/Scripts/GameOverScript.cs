using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScript : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(freezeScreen());
    }

    private IEnumerator freezeScreen()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
