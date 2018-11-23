using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank_ab2 : Ability {

	public void use(enemy e){
		e.recibeDamage(100);
		coolDown = 5;
	}
}
