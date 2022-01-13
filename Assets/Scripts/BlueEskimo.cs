using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEskimo : MonoBehaviour
{

    private bool isPatrolling;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private Transform throwPoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float throwForce;
    [SerializeField] private float patrolSpeed = 3.5f;
    [SerializeField] private int attackDamage = 1;

    private float patrollingDistance = 2.5f;
    private float distancePatrolledLeft;
    private float distancePatrolledRight;
    private AISensor aiSensor;
    private Rigidbody2D Rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 startPosition;
    private Animator enemyAnimator;
    private Vector3 scale;
    private float durationBetweenShots;
    [SerializeField] private float startDurationBetweenShots;

    // Start is called before the first frame update
    void Start()
    {
        aiSensor = GetComponent<AISensor>();
        Rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isPatrolling = true;
        startPosition = transform.position;
        enemyAnimator = GetComponent<Animator>();
        scale = transform.localScale;
        durationBetweenShots = startDurationBetweenShots;
    }
    private void Update()
    {
        enemyAnimator.SetBool("playerDetected", aiSensor.IsPlayerDetected);
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if(isPatrolling)
        {
            Rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            Patrol();
           // bool flipState;
            if (aiSensor.IsPlayerDetected)
            {
                //flipState = spriteRenderer.flipX;
                AttackPlayer();
                
            }
            //else
            //{
            //    isPatrolling = true;
            //    spriteRenderer.flipX = !spriteRenderer.flipX;
            //}
            
        }
        else
        {
            if(aiSensor.IsPlayerDetected)
            {
                AttackPlayer();
            }
            else isPatrolling = true;
        }
    }

    private void Patrol()
    {
        
        if (transform.localScale.x > 0)
        {
            Rb.velocity = new Vector2(-patrolSpeed, 0);

            distancePatrolledLeft = Vector2.Distance(transform.position, startPosition);

          //  Debug.Log(distancePatrolledLeft);
            if (distancePatrolledLeft >= patrollingDistance)
            {
                //Rb.velocity = Vector2.zero;
                //spriteRenderer.flipX = true;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                startPosition = transform.position;
            }
        }

        if(transform.localScale.x < 0)
        {
            Rb.velocity = new Vector2(patrolSpeed, 0);

            distancePatrolledRight = Vector2.Distance(transform.position, startPosition);

            if(distancePatrolledRight >= patrollingDistance)
            {
                //Rb.velocity = Vector2.zero;
                //spriteRenderer.flipX = false;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                startPosition = transform.position;
            }
            
        }

        enemyAnimator.SetFloat("movementSpeed", Mathf.Abs(Rb.velocity.x));

    }

    private void AttackPlayer()
    {

        isPatrolling = false;

        Rb.velocity = Vector2.zero;

        if (playerController.transform.position.x <= transform.position.x)
            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        else transform.localScale = new Vector3(-scale.x, scale.y, scale.z);

        
        if (durationBetweenShots <= 0)
        {
            enemyAnimator.SetTrigger("attack");
            ThrowSpear();
            durationBetweenShots = startDurationBetweenShots;
        }
        else
            durationBetweenShots -= Time.deltaTime;


    }

    private void ThrowSpear()
    {
        GameObject newSpear = Instantiate(projectile, throwPoint.position, throwPoint.rotation);

        
            newSpear.GetComponent<Rigidbody2D>().velocity = (aiSensor.Target.transform.position - throwPoint.position) * throwForce;
    }

}
