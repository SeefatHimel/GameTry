using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform player;



    public void shootBullet()
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = player.transform.position;
    }
}
