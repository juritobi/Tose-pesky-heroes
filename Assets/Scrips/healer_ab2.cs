using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healer_ab2 : Ability {

	public void use(npc[] all){
		foreach (npc h in all) {
			h.RecibeAtaque(-20, null);
			coolDown = 6;
		}
	}
}
