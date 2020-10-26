using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_V3 : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movemoent;
    Vector2 movemoent2;

    public FloatingJoystick joystick;
    // Start is called before the first frame update
   


    private void Update()
    {

        rb.velocity = new Vector2(joystick.Horizontal * 20 * moveSpeed, joystick.Vertical * 15 * moveSpeed);

        movemoent.x = Input.GetAxisRaw("Horizontal");
        movemoent.y = Input.GetAxisRaw("Vertical");



        movemoent2.x = joystick.Horizontal;
        movemoent2.y = joystick.Vertical;
    }



    private void FixedUpdate()
    {


        rb.MovePosition(rb.position + movemoent * moveSpeed * Time.fixedDeltaTime);


        rb.MovePosition(rb.position + movemoent2 * moveSpeed * Time.fixedDeltaTime);

    }



}
