using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_health : MonoBehaviour {

    public int maxhp = 100;
    private int current_hp;
    public int maxmp = 100;
    private int current_mp;


	// Use this for initialization
	void Start () {
        current_hp = maxhp;
        current_mp = maxmp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public int getHp()
    {
        return current_hp;
    }
    public int getMp()
    {
        return current_mp;
    }



    public void TakeDamage(int amount)
    {
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
