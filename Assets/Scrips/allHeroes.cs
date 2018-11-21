using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class allHeroes : MonoBehaviour {
	public hero[] all;

	// Use this for initialization
	void Start () {
		all = FindObjectsOfType<hero>();
	}

	// Update is called once per frame
	void Update () {
	}

	public void attack(enemy e, int atc){
    foreach (hero h in all) {
      if(atc==1){
  			e.recibeDamage(25);
  		}

  		if(atc==2){
  			e.recibeDamage(50);
  		}
    }
	}

	public void recibeDamage(int n){
    foreach (hero h in all) {
      h.health-=n;
      if(h.health<=0){
  			h.health = 0;
  		}
    }
	}
}
