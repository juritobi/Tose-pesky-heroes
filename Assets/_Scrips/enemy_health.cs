using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_health : MonoBehaviour {

    public int maxhp = 100;
    private int current_hp;


    // Use this for initialization
    void Start()
    {
        current_hp = maxhp;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int getHp()
    {
        return current_hp;
    }
    public int getMaxHp()
    {
        return maxhp;
    }
    public void takeDamage(int amount)
    {
        current_hp -= amount;
        if (current_hp <= 0)
        {
            current_hp = 0;
        }
    }

}

