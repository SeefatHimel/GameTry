using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_V2 : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movemoent;



    private bool touchStart = false;

    private Vector2 pointA;
    private Vector2 pointB;
    public Transform player;

    public Camera camera;
    


    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            pointA = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z));

            
        }

        if(Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width / 2)
        {
            touchStart = true;
            pointB = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));

        }
        else
        {
            touchStart = false;
        }
       
        
            movemoent.x = Input.GetAxisRaw("Horizontal");
            movemoent.y = Input.GetAxisRaw("Vertical");


    }
   
    private void FixedUpdate()
    {
        if(touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
                player.Translate(direction * moveSpeed * Time.fixedDeltaTime);

               // moveCharacter(direction);

          //  circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) ;
        }
        else
        {
            
            //circle.GetComponent<SpriteRenderer>().enabled = false;
            //outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
            rb.MovePosition(rb.position + movemoent *moveSpeed * Time.fixedDeltaTime);
        
    }

    void moveCharacter(Vector2 directioin)
    {
        player.Translate(directioin * moveSpeed * Time.fixedDeltaTime);
    }


}
