using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class allHeroes : MonoBehaviour {
	public npc[] all;

	// Use this for initialization
	void Start () {
		all = FindObjectsOfType<npc>();
	}

	// Update is called once per frame
	void Update () {
	}

	public void attack(jugador e, int atc){
    foreach (npc h in all) {
      if(atc==1){
  			e.recibeDamage(25);
  		}

  		if(atc==2){
  			e.recibeDamage(50);
  		}
    }
	}

	public void recibeDamage(int n){
    foreach (npc h in all) {
      h.health-=n;
      if(h.health<=0){
  			h.health = 0;
  		}
    }
	}
}
