﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour {
	public Slider barH;
	public Slider barM;
	public int health;
	public int mana;

	// Use this for initialization
	void Start () {
		health = 2500;
		mana = 100;
	}
	
	// Update is called once per frame
	void Update () {
		barH.value=health;
		barM.value=mana;
	}

	public void attack(hero h, int atc){
		if(atc==1){
			h.recibeDamage(25);
		}

		if(atc==2){
			h.recibeDamage(50);
			mana-=25;
		}
	}

	public void recibeDamage(int n){
		health-=n;
		if(health<0){
			health = 0;
		}
	}
}
