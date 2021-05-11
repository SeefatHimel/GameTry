using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyAI : MonoBehaviour
{

    private Transform target;

    public float speed = 800f;
    public float maxDistance = 5f;
    public float nextWaypointDistance = 3f;

    public Transform player; // the player

    public Animator animator;

    public Transform enemy;  // the enemy body

    public Transform heathbar; // to flip health bar

    public Transform enemyPosition;  // current position of the enemy

    private Vector2 initialPosition;    // initial position of the enemy

    public float atkDistance = 2f;  // distance where the enemy should atk

    public float forcePower = 2f; // to control the force


    float time1, tim2 = 1f;

    public float yminDistance = 3f;


    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    private bool attcking = false;



    // for atk rate
    public float atkRate = 0.5f; // how many atk per sec
    float nxtArkTime = 0f; // when we can atrk again



    // Start is called before the first frame update
    void Start()
    {
        target = player;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        initialPosition = rb.position;

        InvokeRepeating("UpdatePath", 0f, .5f);

        time1 = Time.time;
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }


    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }





    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }


        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        Vector2 zeroForce = direction * 0f;


        float targetDistacnce = Vector2.Distance(rb.position, target.position);
        float playerDistacnce = Vector2.Distance(rb.position, player.position);
        float positionDistacnce = Vector2.Distance(rb.position, enemyPosition.position);

        animator.SetFloat("Speed", Mathf.Max(Mathf.Abs(force.x), Mathf.Abs(force.y)));

        


        //Cotroling the force
        force.x = force.x * forcePower / Mathf.Abs(force.x);
        force.y = force.y * forcePower / Mathf.Abs(force.y);

        animator.SetFloat("distance", playerDistacnce); // seting target distance in the animator

        //stoping the force when in atk range
        if (targetDistacnce > atkDistance && !animator.GetCurrentAnimatorStateInfo(0).IsTag("Natk"))
        {
            rb.AddForce(force);



            //if (Mathf.Abs (rb.position.y - target.position.y + 0.3f) < 0.1 )
            //{
            //    rb.velocity = new Vector3(rb.velocity.x, 0f, 0f);

            //}
            //else if ( targetDistacnce < yminDistance)
            //{
            //    rb.velocity = new Vector3( 0f, rb.velocity.y, 0f);

            //}


        }
        else if (target == player && playerDistacnce <= atkDistance)
        {
            // rb.AddForce(zeroForce);

            rb.velocity = Vector3.zero;



            if (Time.time >= nxtArkTime && target == player && !animator.GetCurrentAnimatorStateInfo(0).IsTag("Natk"))
            {
                nxtArkTime = Time.time + 1f / atkRate; // Setting nxt atk time

                animator.SetTrigger("atk");
            }
        }



        //Debug.Log("           Force  :  " + force); //display force

        if (positionDistacnce > 10f || playerDistacnce > maxDistance)
            target = enemyPosition;


        else if (playerDistacnce <= maxDistance)
            target = player;




        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);


        if (distance < nextWaypointDistance)
        {

            currentWaypoint++;
            // Print distance
            // Debug.Log(" player distance = " + playerDistacnce);
        }

        // for fliping the enemy
        if (rb.position.x < target.position.x)
        {
            enemy.localScale = new Vector3(-1f, 1f, 1f);
            heathbar.localScale = new Vector3(-0.01f, 0.01f, 0.01f);
        }
        else if (rb.position.x > target.position.x)
        {
            enemy.localScale = new Vector3(1f, 1f, 1f);
            heathbar.localScale = new Vector3(0.01f, 0.01f, 0.01f);

        }
    }
}