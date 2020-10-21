using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_atk : MonoBehaviour
{
    public Animator animator;
    float spd;

    
    private void Update()
    {
        spd = animator.speed;
        
    }

    public void swordAtk()
    {
       // Debug.Log("speed      " + spd);
     //   if(spd <0.1f)
     if(!this.animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack_animation"))
        animator.SetTrigger("Atk");
    }


}
