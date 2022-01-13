using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCollision : MonoBehaviour
{
    public PlayerController playerController;


    private void OnTrigger2DEnter(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerController.HealthBar.GetHurt(1);
            //StartCoroutine(playerController.EnterInvincibilityState());
        }
    }

}
