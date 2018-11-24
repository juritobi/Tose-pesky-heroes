using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank_ab1 : Ability {

	public void use(jugador e){
		e.recibeDamage(50);
		coolDown = 3;
	}
}
