using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_atk : MonoBehaviour
{
    public Animator animator;
    float spd;

    public Transform atkPoint;
    public float atkRange;
    public LayerMask enemyLayer;
    public int weaponDmg = 50;

    // for atk rate
    public float atkRate = 1f; // how many atk per sec
    float nxtArkTime = 0f; // when we can atrk again


    void Update()
    {
        spd = animator.speed;

    }

    public void swordAtk()
    {

        if(Time.time >= nxtArkTime)
        {
            nxtArkTime = Time.time + 1f / atkRate; // Setting nxt atk time

        if (!this.animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack_animation")) // So that one cant atk while in atk animation 
        {

            animator.SetTrigger("Atk");


            Collider2D[] hit_enemies = Physics2D.OverlapCircleAll(atkPoint.position, atkRange, enemyLayer);

            foreach (Collider2D enemy in hit_enemies)
            {
                Debug.Log("We hit " + enemy.name + " " + weaponDmg);

                enemy.GetComponent<life>().TakeDamage(weaponDmg);


            }

        }
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (atkPoint == null)
            return;

        Gizmos.DrawWireSphere(atkPoint.position, atkRange);
    }


}
