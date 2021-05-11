using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  Script is mainly called from the button not from the player
/// </summary>



public class Sword_atk : MonoBehaviour
{
    public Animator animator;
    float spd;

    public Transform atkPoint;
    public float atkRange;
    public LayerMask enemyLayer;
    public int weaponDamage;

    // for atk rate
    public float atkRate = 1f; // how many atk per sec
    float nxtArkTime = 0f; // when we can atrk again


  

    void Update()
    {
        spd = animator.speed;

    }

    public void atkTrigger()
    {

        if(Time.time >= nxtArkTime)
        {
            nxtArkTime = Time.time + 1f / atkRate; // Setting nxt atk time


            animator.SetTrigger("Atk");
       

        }

    }

    public void swordAtk()
    {


            Collider2D[] hit_enemies = Physics2D.OverlapCircleAll(atkPoint.position, atkRange, enemyLayer);

            foreach (Collider2D enemy in hit_enemies)
            {
                Debug.Log("We hit " + enemy.name + " " + weaponDamage);

                enemy.GetComponent<life>().TakeDamage(weaponDamage);


            }

    }

    private void OnDrawGizmosSelected()
    {
        if (atkPoint == null)
            return;

        Gizmos.DrawWireSphere(atkPoint.position, atkRange);
    }



    public void SwordAtkSoundPlayer()
    {
        FindObjectOfType<AudioManager>().Play("SwordSound2");
    }

}
