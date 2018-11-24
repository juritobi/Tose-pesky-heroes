using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healer_ab1 : Ability {
	npc heroe;
	int min = 100;
	public void use(npc[] all){
		foreach (npc h in all) {
			if(h.hp<min){
				min = h.hp;
				heroe = h;
			}
		}

		heroe.cambiaHp(-50);
		coolDown = 2;
	}
}
