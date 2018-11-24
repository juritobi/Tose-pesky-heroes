using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dps_ab2 : Ability {

	public void use(personaje e){
		e.cambiaHp(550);
		coolDown = 5;
	}


}
