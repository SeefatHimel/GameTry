using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_atk_trigger : MonoBehaviour
{
    public Animator animator;
   

    // for atk rate
    public float atkRate = 1f; // how many atk per sec
    float nxtArkTime = 0f; // when we can atrk again




    void Update()
    {

    }

    public void atkTrigger()
    {

        if (Time.time >= nxtArkTime)
        {
            nxtArkTime = Time.time + 1f / atkRate; // Setting nxt atk time


            animator.SetTrigger("Atk");


        }

    }

    

}
