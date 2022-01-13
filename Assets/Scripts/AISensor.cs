using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensor : MonoBehaviour
{
    private bool isPlayerDetected;

    private Rigidbody2D Rb;

    [SerializeField] private float threshold;

    [SerializeField] private GameObject target;

    public bool IsPlayerDetected { get => isPlayerDetected; set => isPlayerDetected = value; }
    public GameObject Target { get => target; set => target = value; }
    public float Threshold { get => threshold; set => threshold = value; }

    private void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, Target.transform.position) ;

        if (distanceToTarget < Threshold)
        {
            IsPlayerDetected = true;
            Debug.Log("Player is in range!");
        }
        else IsPlayerDetected = false;

    }

    private void Start()
    {

        Rb = GetComponent<Rigidbody2D>();

        IsPlayerDetected = false;

    }

    



}
