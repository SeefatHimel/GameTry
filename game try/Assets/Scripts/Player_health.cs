using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health : MonoBehaviour
{
    public health_bar healthBar;
    public int max_hp = 100;
    int current_hp;



    // Start is called before the first frame update
    void Start()
    {
        current_hp = max_hp;
        healthBar.SetMaxHealth(max_hp);
        healthBar.SetHealth(max_hp);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int playerHP()
    {
        return current_hp;
    }

    public void damagePlayer(int damage)
    {
        //play hurt animation

        current_hp -= damage;
        healthBar.SetHealth(current_hp);


        //what happens when player die
    }

    public void absorbeLife(int hp)
    {
        current_hp += hp;
        if (current_hp > max_hp)
            current_hp = max_hp;
        healthBar.SetHealth(current_hp);
    }
    public bool fullHp()
    {
        if (current_hp == max_hp)
            return true;
        else return false;
    }
}
