using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitPanelInteractions : MonoBehaviour
{

    public GameObject exitPanel;

    public void confirmExit()
    {
        SceneManager.LoadScene(0);
    }

    public void notConfirmExit()
    {
        exitPanel.SetActive(false);
        Time.timeScale = 1f;
    }

}
