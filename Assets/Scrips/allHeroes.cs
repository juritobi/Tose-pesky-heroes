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
  			e.cambiaHp(25);
  		}

  		if(atc==2){
  			e.cambiaHp(50);
  		}
    }
	}

	public void recibeDamage(int n){
    foreach (npc h in all) {
      h.hp-=n;
      if(h.hp<=0){
  			h.hp = 0;
  		}
    }
	}
}
