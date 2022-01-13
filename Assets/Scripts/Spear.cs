using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{


    private Rigidbody2D Rb;
    private SpriteRenderer spriteRenderer;
    private Collider2D spearCollider2D;
    [SerializeField] private Sprite brokenSpear;

    private float stickingTimeDuration = 2.0f;
    private float stickingTimeFrames = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spearCollider2D = GetComponent<Collider2D>();
    }

    
    void Update()
    {
        if (!Rb.isKinematic)
        {
            float angle = Mathf.Atan2(Rb.velocity.y, Rb.velocity.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            transform.parent = collision.gameObject.transform;
            Rb.isKinematic = true;
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(activateFlashingState());
            //Destroy(gameObject);
        }
       
    }

    private IEnumerator activateFlashingState()
    {
        Rb.velocity = Vector2.zero;
        Rb.freezeRotation = true;
        yield return new WaitForSeconds(1f);
        for (float i = 0; i <= stickingTimeDuration; i += stickingTimeFrames)

        {
            if (spriteRenderer.enabled == true)
            {
                spriteRenderer.enabled = false;
            }
            else
            {
                spriteRenderer.enabled = true;
            }


            yield return new WaitForSeconds(stickingTimeFrames);
        }
        
        spriteRenderer.enabled = true;
        Destroy(gameObject);
    }

    

   
}
