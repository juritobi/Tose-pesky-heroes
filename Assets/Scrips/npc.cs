using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;





public class npc : personaje {

    public bool clicked;
    public CheckClicked MeAndJustMe;
    public Animator spriter;
    public String anim;
    // Use this for initialization
    protected override void Start() {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        // StartCoroutine(waitchange());
        if (clicked == true)
        {
            spriter.Play(anim, -1, 0);
        }
        /* else
         {
             spriter.Play("none");
         }*/
    }
    public void MyDelay(int seconds) {
        DateTime dt = DateTime.Now + TimeSpan.FromSeconds(seconds);
        do { } while (DateTime.Now < dt);
    }
    public override void muerto()
    {
        ReySlime enemy = FindObjectOfType<ReySlime>();
        base.muerto();
        enemy.devorar();
    }

	void OnMouseDown(){
		clicked = true;
        MeAndJustMe.Check(this);
	}
    IEnumerator waitchange()
    {
        yield return new WaitForSeconds(1);
    }
}
