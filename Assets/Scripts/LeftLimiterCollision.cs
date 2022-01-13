using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftLimiterCollision : MonoBehaviour
{

    [SerializeField] private GameObject wrongWayText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            
            wrongWayText.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            
            wrongWayText.SetActive(false);
        }
    }

}
