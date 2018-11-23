using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healer_ab1 : Ability {
	hero heroe;
	int min = 100;
	public void use(hero[] all){
		foreach (hero h in all) {
			if(h.health<min){
				min = h.health;
				heroe = h;
			}
		}

		heroe.cambiaVida(-50);
		coolDown = 2;
	}
}
