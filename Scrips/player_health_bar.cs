using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_health_bar : MonoBehaviour {

    public player_health player;
    public Text hp;
    public Slider bar;
    public Slider mana;
 
    
   
	// Use this for initialization
	void Start () {
        hp.text = "HP: " + player.getHp();
        
        
        setbar();



       
	}
	
	// Update is called once per frame
	void Update () {
       
        hp.text = "HP: " + player.getHp();
        bar.value = player.getHp();
        mana.value = player.getMp();
        
    }
    void setbar()
    {
        bar.maxValue = player.getMaxHp();
        mana.maxValue = player.getMaxMp();
    }
}
