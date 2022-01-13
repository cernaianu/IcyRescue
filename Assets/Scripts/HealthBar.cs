using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{


    [SerializeField]private AnimationManager animationManager;
    [SerializeField]private List<Heart> hearts;
    
    private int heartCount;
    private bool hasBeenHurt = false;
    private bool isInvincible = false;

    public List<Heart> Hearts { get => hearts; set => hearts = value; }
    public int HeartCount { get => heartCount; set => heartCount = value; }
    public bool HasBeenHurt { get => hasBeenHurt; set => hasBeenHurt = value; }
    public bool IsInvincible { get => isInvincible; set => isInvincible = value; }





    // Start is called before the first frame update
    void Start()
    {
        heartCount = hearts.Count;
    } 


    // Update is called once per frame
    void Update()
    {
        
    }

    //Get hurt; empties one heart
    public void GetHurt(int damage)
    {
        if (!IsInvincible)
        {
            if (heartCount == 0)
                return;

            if (damage > 3)
            {
                damage = 3;
            }

            for (int i = 1; i <= damage; i++)
            {
                
                hearts[HeartCount - 1].GetDamaged();

                HeartCount--;
                //hearts.RemoveAt(hearts.Count - 1);
            }
                hasBeenHurt = true;
            
            animationManager.GetPlayerAnimator().SetTrigger("isHurting");
        }

    }

    public void Heal()
    {
        
        hearts[HeartCount + 1].GetHealed();
        HeartCount++;
    }


}
