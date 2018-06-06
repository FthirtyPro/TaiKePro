using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationPlay : MonoBehaviour {

    private Animator animator;
    public Skill skill;

    void Awake()
    {
        animator =transform.GetComponent<Animator>();
    }

	public void OnAttackButtonClick(bool ispress, PosType posType)
    {
        if(posType ==PosType.Basic)
        {
           if(ispress)
           {
               animator.SetTrigger("attack");
           }
        }else{
            if(ispress)
            {
                animator.SetBool("skill"+(int)posType,true);
            }else{
                 animator.SetBool("skill"+(int)posType,false);
            }
        }
    }
}
