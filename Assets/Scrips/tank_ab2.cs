using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank_ab2 : Ability {

	public void use(personaje e){
		e.cambiaHp(100);
		coolDown = 5;
	}
}
