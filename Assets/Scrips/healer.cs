using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healer : npc {
	public Ability h1, h2;

	public void decision(npc[] all){
		if(h2.coolDown==0){
			healer_ab2 hab2 = (healer_ab2) h2;
			hab2.use(all);
		}

		else if(h1.coolDown==0){
			healer_ab1 hab1 = (healer_ab1) h1;
			hab1.use(all);
		}

	}
}
