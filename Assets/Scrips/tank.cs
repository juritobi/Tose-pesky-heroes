using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : hero {

	public Ability h1, h2;

	public void decision(enemy e){
		if(h2.coolDown==0){
			tank_ab2 hab2 = (tank_ab2) h2;
			hab2.use(e);
		}

		else if(h1.coolDown==0){
			tank_ab1 hab1 = (tank_ab1) h1;
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
