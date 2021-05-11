using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    public Animator animator;
    float spd;

    public Transform atkPoint;
    public float atkRange;
    public LayerMask playerLayer;
    public int weaponDamage;


    void Update()
    {
        spd = animator.speed;

    }

    public void atkPlayer()
    {

        Collider2D[] hit_player = Physics2D.OverlapCircleAll(atkPoint.position, atkRange, playerLayer);

        foreach (Collider2D players in hit_player)
        {
            Debug.Log(this.name +  " hit " + players.name + " " + weaponDamage);

            players.GetComponent<Player_health>().damagePlayer(weaponDamage);


        }


    }

    public void playAtkSoundForEnemy()
    {
        FindObjectOfType<AudioManager>().Play("SwordSound1");
    }

    private void OnDrawGizmosSelected()
    {
        if (atkPoint == null)
            return;

        Gizmos.DrawWireSphere(atkPoint.position, atkRange);
    }

}
