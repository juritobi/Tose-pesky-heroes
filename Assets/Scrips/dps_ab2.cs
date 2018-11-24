using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dps_ab2 : Ability {

	public void use(jugador e){
		e.recibeDamage(550);
		coolDown = 5;
	}


}
