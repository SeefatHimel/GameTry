using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_movimentV2 : MonoBehaviour
{
    public Transform player; // player
    public Transform enemy;

    private Transform target;

    public Transform initialPosition;

    public float speed = 0.008f;
    public float minDistanceToFollowPlayer = 5f; // enemy will stop following 
    public float maxDistaceFromInitialPosition = 10f;
    public float atkDistance=1.5f ;

   

    public Rigidbody2D rb; // enemy body

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        target = initialPosition;
        
    }
    void FixedUpdate()
    {
        float targetDistacnce = Vector2.Distance(rb.position, target.position);
        float playerDistacnce = Vector2.Distance(rb.position, player.position);
        float positionDistacnce = Vector2.Distance(rb.position, initialPosition.position);

        if (playerDistacnce <= minDistanceToFollowPlayer)
            target = player;
        else
            target = initialPosition;

        //rb.MovePosition(target.position * speed * Time.deltaTime);


        Debug.Log("Target  =  " + target.name);
        Debug.Log("Distance = " + targetDistacnce);
        Debug.Log("Player Distance = " + playerDistacnce);




        Vector2.MoveTowards(rb.position, target.position, speed * Time.fixedDeltaTime);


    }
}
