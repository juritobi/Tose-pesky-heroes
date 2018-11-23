using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dps_ab1 : Ability {

	public void use(enemy e){
		e.recibeDamage(100);
		coolDown = 3;
	}
}
