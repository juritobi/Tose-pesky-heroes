using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;





public class npc : MonoBehaviour {
	public jugador enemigo;
	public Slider barH;
	public int maxHealth;
	public int health;
	public int defensa;
	public bool clicked;
	public bool dead;
	protected List<string> estados;

	// Use this for initialization
	void Start () {
		enemigo = (jugador)FindObjectOfType(typeof(jugador));
		maxHealth=100;
		health = maxHealth;
		estados=new List<string>();
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

	public void attack(jugador e, int atc){
		if(atc==1){
			e.recibeDamage(25);
		}

		if(atc==2){
			e.recibeDamage(50);
		}
	}

	public void RecibeAtaque(int cantidad, string[] states){
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
		if (states!=null) {
			foreach (string e in states) {
				estados.Add(e);
			}
		}
	}

	public void eliminaEstado(string state){
		estados.Remove(state);
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
