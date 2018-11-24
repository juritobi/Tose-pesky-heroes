using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healer_ab1 : Ability {
	npc heroe;
	int min = 100;
	public void use(npc[] all){
		foreach (npc h in all) {
			if(h.health<min){
				min = h.health;
				heroe = h;
			}
		}

		heroe.RecibeAtaque(-50,null);
		coolDown = 2;
	}
}
