using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;





public class npc : personaje {

	public bool clicked;
	// Use this for initialization
	protected override void Start () {
        base.Start();
    }
    public void MyDelay( int seconds ){
  		DateTime dt = DateTime.Now + TimeSpan.FromSeconds( seconds );
		do {} while ( DateTime.Now <dt );
	}

	void OnMouseDown(){
		clicked = true;
	}
}
