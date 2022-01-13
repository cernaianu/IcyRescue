using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private AnimationManager animationManager;

    private bool hasBeenHurt = false;
    private bool isInvincible = false;
    private Rigidbody2D rb;
    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;
    private Collider2D circlePlayerCollider2D;
    private int playerHealth;
    [SerializeField]private float invincibleTimeDuration;
    [SerializeField] private float invincibleTimeFrames;
    public Rigidbody2D Rb { get => rb; set => rb = value; }
    public Animator PlayerAnimator { get => playerAnimator; set => playerAnimator = value; }
    public SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }
    public Collider2D   CirclePlayerCollider2D { get => circlePlayerCollider2D; set => circlePlayerCollider2D = value; }
    public int PlayerHealth { get => playerHealth; set => playerHealth = value; }
    public HealthBar HealthBar { get => healthBar;  }
    public bool HasBeenHurt { get => hasBeenHurt; set => hasBeenHurt = value; }


    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        PlayerAnimator.tag = "Player";
        SpriteRenderer = GetComponent<SpriteRenderer>();
        CirclePlayerCollider2D = GetComponent<CircleCollider2D>();
        
       // healthBar = FindObjectOfType<HealthBar>();
        
    }

    


    // Update is called once per frame
    void Update()
    {
        PlayerHealth = healthBar.HeartCount;
        HasBeenHurt = healthBar.HasBeenHurt;
        animationManager.GetPlayerAnimator().SetBool("isInvincible", HealthBar.IsInvincible);
    }

    public bool isDead()
    {
        return (PlayerHealth == 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Projectile"))
        {
            HealthBar.GetHurt(1);
            // BounceBackOnDamage();
            
            StartCoroutine(EnterInvincibilityState());

            

            //collision.rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public IEnumerator EnterInvincibilityState()
    {



        
        HealthBar.IsInvincible = true;

        IgnoreCollisionsWhileInvincible();
        //invincibility frames acquiring
        for (float i = 0; i <= invincibleTimeDuration; i += invincibleTimeFrames)

        {
            
            if (SpriteRenderer.enabled == true)
            {
                SpriteRenderer.enabled = false;
            }
            else
            {
                SpriteRenderer.enabled = true;
            }


            yield return new WaitForSeconds(invincibleTimeFrames);
        }

        SpriteRenderer.enabled = true;
        HealthBar.IsInvincible = false;
        EnableCollisionsAfterInvincibility();



    }

    private void BounceBackOnDamage()
    {
        Rb.AddForce(new Vector2(-2.0f, 1.7f), ForceMode2D.Impulse);
    }


    private void IgnoreCollisionsWhileInvincible()
    {
        Physics2D.IgnoreLayerCollision(7, 0, true);
    }

    private void EnableCollisionsAfterInvincibility()
    {
        Physics2D.IgnoreLayerCollision(7, 0, false);
    }

    public bool isOnSlipperySurface()
    {
        RaycastHit2D hitData = Physics2D.Raycast(GetComponent<CircleCollider2D>().bounds.center, Vector2.down, 2f, LayerMask.GetMask("Ground"));
        //Debug.DrawRay(GetComponent<CircleCollider2D>().bounds.center, Vector2.down, Color.red, 4f );
        if(hitData && hitData.collider.CompareTag("Ice"))
        {
            return true;
        }
        return false;
    }

}
