using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this is for enemy life

public class life : MonoBehaviour
{
    public int max_hp = 100;
    public int current_hp;
    public Animator animator;

    public health_bar healthbar;


    public float deathTime = 1f; // time to die XD
    float deadTime ; // time to die XD
   // public Object body;

    void Start()
    {
        current_hp = max_hp;
        healthbar.SetMaxHealth(max_hp);
        healthbar.SetHealth(max_hp);
    }

    private void FixedUpdate()
    {
        if(current_hp <=0 )
        {
       
            die();
        }
        
    }

    public void TakeDamage(int dmg_point)
    {
        current_hp -= dmg_point;

        healthbar.SetHealth(current_hp);

        Debug.Log("HP left : " + current_hp);

        // play dmg animation
        animator.SetTrigger("hurt");


        if(current_hp <=0 )
        {
       
        deadTime = Time.time + deathTime;
            die();
        }

    }


    void die()
    {
        // Die animation - just for the time
        animator.SetTrigger("hurt");
        if(Time.time>= deadTime)
        {

        // Disable enemy to show dead body but i dont have atm

        // destroy object
         //   Debug.Log(this.animator.GetCurrentAnimatorStateInfo(0));

        Debug.Log("Enemy died");
        Destroy(this.gameObject);

        }

    }

 
}
