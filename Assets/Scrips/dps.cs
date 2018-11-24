using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dps : npc {


    public void decision(personaje e)
    {
        flechaEnvenenada(e);
    }



    public void flechaEnvenenada(personaje e){
		e.cambiaHp(300);
	}
	public void basico(personaje e)
    {
		e.cambiaHp(200);
	}
	public void mucho(personaje e)
    {
		e.cambiaHp(200);
	}

	

}
