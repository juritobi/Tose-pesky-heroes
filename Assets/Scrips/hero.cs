using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hero : MonoBehaviour {
	public Slider barH;
	public int health;
	public bool clicked;
	public bool dead;

	// Use this for initialization
	void Start () {
		health = 100;
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

	public void recibeDamage(int n){
		health-=n;
		if(health<=0){
			health = 0;
		}
	}

	void OnMouseDown(){
		clicked = true;
	}

	void DestroyGameObject(){
		Destroy(barH);
		Destroy(gameObject);   //metodo que elimina el objeto
	}
}
