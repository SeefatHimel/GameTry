using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movemoent;



    private bool touchStart = false;
    private bool lHalf = false;

    private Vector2 pointA;
    private Vector2 pointB;
    public Transform player;

    public Transform circle = null;
    public Transform outerCircle;
    
    





    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0) && Input.mousePosition.x < Screen.width / 2)
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z));

            circle.transform.position = pointA;
            outerCircle.transform.position = pointA ;

            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }

        if(Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width / 2)
        {
            touchStart = true;
            if (Input.mousePosition.x < Screen.width / 2)
                lHalf = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));

        }
        else
        {
            touchStart = false;
            lHalf = false;
        }
       
        if( Input.mousePosition.x < Screen.width / 2)
        {
            movemoent.x = Input.GetAxisRaw("Horizontal");
            movemoent.y = Input.GetAxisRaw("Vertical");
        }


    }
   
    private void FixedUpdate()
    {


     






        // if(lHalf)
        {
            if (touchStart && lHalf)
        {
            Vector2 offset = pointB - pointA;



            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
                player.Translate(direction * moveSpeed * Time.fixedDeltaTime);

               // moveCharacter(direction);

            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) ;
        }
        else
        {
            
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }

            rb.MovePosition(rb.position + movemoent *moveSpeed * Time.fixedDeltaTime);

        }



        
    }

    void moveCharacter(Vector2 directioin)
    {
        player.Translate(directioin * moveSpeed * Time.fixedDeltaTime);
    }


}
