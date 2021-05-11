using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plusLife : MonoBehaviour
{
    GameObject gb; // player
    public GameObject gbLife;
    public Transform lifeIcon;
    Rigidbody2D rbPlayer;
    public int hp = 30;
    public float lifeDistance = 0.5f; // when will the life will be comsumed 

    // Start is called before the first frame update
    void Start()
    {
        gb = GameObject.FindWithTag("Player");

        rbPlayer = gb.GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(rbPlayer.position, lifeIcon.position);
   //     Debug.Log(distanceToPlayer);
        if(distanceToPlayer < lifeDistance && !rbPlayer.GetComponent<Player_health>().fullHp())
        {

            FindObjectOfType<AudioManager>().Play("LifePickup");
            rbPlayer.GetComponent<Player_health>().absorbeLife(hp);
            Destroy(gbLife);
        }
    }

    

}
