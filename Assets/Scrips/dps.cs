using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dps : npc {
	public Ability h1, h2;



	public void flechaEnvenenada(){
		base.enemigo.recibeAtaque(20, new string[] {"veneno"});
	}
	public void basico(){
		base.enemigo.recibeAtaque(200, null);
	}
	public void mucho(){
		base.enemigo.recibeAtaque(200, null);
	}

	public void decision(jugador e){
		flechaEnvenenada();
	}

	public void basicAttack(jugador e){
		e.recibeDamage(15);
	}

}
