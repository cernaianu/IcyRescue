using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField]private Sprite damagedHeart;
    [SerializeField] private Sprite healthyHeart;
    private SpriteRenderer spriteRenderer;
    private Animator heartAnimator;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        heartAnimator = GetComponent<Animator>();
        spriteRenderer.sprite = healthyHeart;
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamaged()
    {
        heartAnimator.SetTrigger("Hurt");
        spriteRenderer.sprite = damagedHeart;
    }

    public void GetHealed()
    {
        spriteRenderer.sprite = healthyHeart;
        
    }

}
