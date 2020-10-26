using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_V3 : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Transform player;

    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;
    Vector2 movement2;

    public FloatingJoystick joystick;
    // Start is called before the first frame update



    private void Update()
    {

        rb.velocity = new Vector2(joystick.Horizontal * 20 * moveSpeed, joystick.Vertical * 15 * moveSpeed);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");



        movement2.x = joystick.Horizontal;
        movement2.y = joystick.Vertical;



    }



    private void FixedUpdate()
    {

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("Speed", Mathf.Max( Mathf.Abs(movement.x), Mathf.Abs(movement.y)));
        }
        else
        {
            animator.SetFloat("Speed", Mathf.Max( Mathf.Abs(movement2.x), Mathf.Abs(movement2.y)));
        }


      //  Debug.Log(" X position = " + movement2.x);
      //  Debug.Log(" Xx position = " + movement.x);



        //for arrow keys
        if(!this.animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack_animation"))
        {

        if (movement.x >= .01f || movement2.x >= .01f)
        {
            player.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (movement.x <= -.01f || movement2.x <= -.01f)
        {
            player.localScale = new Vector3(-1f, 1f, 1f);

        }

        if(movement2.x==0 && movement2.y==0)
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //for Joystick
        else
        rb.MovePosition(rb.position + movement2 * moveSpeed * Time.fixedDeltaTime);


        }
    }



}
