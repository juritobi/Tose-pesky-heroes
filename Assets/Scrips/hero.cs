﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class hero : MonoBehaviour {
	public Slider barH;
	public int maxHealth;
	public int health;
	public int defensa;
	public bool clicked;
	public bool dead;

	// Use this for initialization
	void Start () {
		maxHealth=100;
		health = maxHealth;
		clicked = false;
		dead = false;
	}

	// Update is called once per frame
	void Update () {
		barH.value=health;
		if(barH.value==0){
			this.DestroyGameObject();
		}
	}

	public void attack(enemy e, int atc){
		if(atc==1){
			e.recibeDamage(25);
		}

		if(atc==2){
			e.recibeDamage(50);
		}
	}

	public void cambiaVida(int cantidad){
		if (cantidad>0) {
			health-=cantidad+defensa;
			if(health<0){
				health = 0;
			}
		}
		else{
			health-=cantidad;
			if(health>maxHealth){
				health=maxHealth;
			}
		}
	}


	public void MyDelay( int seconds ){
  		DateTime dt = DateTime.Now + TimeSpan.FromSeconds( seconds );
		do {} while ( DateTime.Now <dt );
	}

	void OnMouseDown(){
		clicked = true;
	}

	void DestroyGameObject(){
		Destroy(barH);
		Destroy(gameObject);   //metodo que elimina el objeto
	}
}
