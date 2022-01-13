using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{

    public PlayerController playerController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            playerController.PlayerAnimator.SetBool("dead", true);
        else
        Destroy(collision.gameObject);
    }




}
