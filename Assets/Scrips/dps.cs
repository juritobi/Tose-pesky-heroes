using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dps : hero {
	public Ability h1, h2;

	public void decision(enemy e){
		if(h2.coolDown==0){
			dps_ab2 hab2 = (dps_ab2) h2;
			hab2.use(e);
		}

		else if(h1.coolDown==0){
			dps_ab1 hab1 = (dps_ab1) h1;
			hab1.use(e);
		}

		else{
			basicAttack(e);
		}
	}

	public void basicAttack(enemy e){
		e.recibeDamage(15);
	}

	
}
