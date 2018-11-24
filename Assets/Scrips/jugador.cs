using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class jugador : MonoBehaviour {
	public Slider barH;
	public Slider barM;
	public int defensa;
	public int maxHealth;
	public int manabase;
	public int health;
	public int mana;
	protected List<string> estados;


	// Use this for initialization
	void Start () {
		maxHealth =2500;
		manabase =100;
		health = 2500;
		mana = 100;
		estados=new List<string>();
	}

	// Update is called once per frame
	void Update () {
		barH.value=health;
		barM.value=mana;
	}

	public void attack(npc h, int atc){
		if(atc==1){
			h.RecibeAtaque(25, null);
		}

		if(atc==2){
			h.RecibeAtaque(50, null);
			mana-=25;
		}
	}

	public void recibeAtaque(int cantidad, string[] states){
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

	public void recibeDamage(int n){
		health-=n;
		if(health<0){
			health = 0;
		}
	}

	public void recibeCuracion(int c)
	{
			health = health + c;
			if (health >=maxHealth)
			{
					health = maxHealth;
			}
	}
	public void recibeMana(int c)
	{
			mana = mana + c;
			if (mana >=manabase)
			{
					mana = manabase;
			}
	}
	public void aumentaDefensa(int def)
	{
			defensa = defensa + def;
	}
	public void reduceDefensa(int def)
	{
		defensa = defensa - def;
	}
}
