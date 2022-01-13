using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    
    [SerializeField] private List<Animator> animatorList;

    public List<Animator> AnimatorList { get => animatorList; set => animatorList = value; }


    public Animator GetPlayerAnimator()
    {
        return AnimatorList.Find(a => a.CompareTag("Player"));
    }

    

}
