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

    public Transform player;

    
    public Transform enemy;

    public Transform enemyPosition;

    private Vector2 initialPosition;


    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        target = player;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        initialPosition = rb.position;

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }


    void OnPathComplete(Path p)
    {
        if(!p.error)
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

        if(currentWaypoint >= path.vectorPath.Count)
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

        rb.AddForce(force);

        float targetDistacnce = Vector2.Distance(rb.position, target.position);
        float playerDistacnce = Vector2.Distance(rb.position, player.position);
        float positionDistacnce = Vector2.Distance(rb.position, enemyPosition.position);

        if (targetDistacnce > maxDistance)
            target = enemyPosition ;


        if (playerDistacnce < maxDistance && positionDistacnce < 1f)
            target = player;

        if (positionDistacnce > 10f)
            target = enemyPosition;



        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        

        if(distance < nextWaypointDistance)
        {

            currentWaypoint++;
            Debug.Log(" player distance = " + playerDistacnce);
        }

        if(force.x >=.01f)
        {
            enemy.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <=-.01f)
        {
            enemy.localScale = new Vector3(1f, 1f, 1f);

        }
    }
}
