using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_health : MonoBehaviour {

    public int maxhp = 100;
    private int current_hp;
    public int maxmp = 100;
    private int current_mp;
    public const int attack1 = 10;
    //private float critChance = 0.1f;
    private float critMult = 1.3f; //base


    // Use this for initialization
    void Start() {
        current_hp = maxhp;
        current_mp = maxmp;
    }

    // Update is called once per frame
    void Update() {

    }

    public void reliquiaCrit(bool tiene)
    {
        if (tiene)
        {
            critMult += 0.3f;
        }

    }
        

        

    public int getHp()
    {
        return current_hp;
    }
    public int getMp()
    {
        return current_mp;
    }

    /*
    public int damageattack1()
    {
        float isCrit = Random.Range(0f,2f);
        if (isCrit >= critChance) ;
        return attack1;
    }
    */
    public void TakeDamage(int amount)
    {
       amount -= amount * 2 / 3;
        current_hp -= amount;
        if (current_hp <= 0)
        {
            current_hp = 0; 
        }
    }

    public void Usemp(int amount)
    {
       
        current_mp -= amount;
    }




    public int getMaxHp()
    {
        return maxhp;
    }
    public int getMaxMp()
    {
        return maxmp;
    }    
}
