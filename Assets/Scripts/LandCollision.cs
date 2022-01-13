using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandCollision : MonoBehaviour
{
    PlayerController playerController;
    private bool onLand;

    private void Start()
    {
        playerController.GetComponent<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
        playerController.PlayerAnimator.SetBool("isOnLand", onLand);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onLand = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        onLand = true;
    }

}
