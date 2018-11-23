using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healer_ab2 : Ability {

	public void use(hero[] all){
		foreach (hero h in all) {
			h.cambiaVida(-20);
			coolDown = 6;
		}
	}
}
