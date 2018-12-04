﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReySlime : personaje {

	// Use this for initialization
	protected override void Start () {

        mhp = 2000;
        ad = 90;
        ap = 135;
        def = 200;
        mr = 75;

        
        base.Start();

    }
	

	// Update is called once per frame
	
   

    public void salpicar(npc[] en,int dan)

    {
        int dandiv = (int)(0.1*dan);
        int i;
        for(i=0;i<en.Length;i++){
            if(en[i].gameObject.activeSelf)
              en[i].cambiaHp(dandiv,'t');
        }

       
        
        


    }
    public void devorar()
    {
        int aumenta = (int)(0.1 * hp);
        cambiaHp(aumenta, 'c');
    }
    public void disparoMoco(npc n1)
    {
        int disminuye = (int)(0.03 * hp);
        cambiaHp(disminuye, 't');
        n1.cambiaHp(ap, 'm');
        n1.recibeEstado("congelado", 1);
    }
    public void lluviaAcida(npc[] en)
    {
        int disminuye = (int)(0.07 * hp);
        cambiaHp(disminuye, 't');
        recibeEstado("hablluvia", 2);
        int i;
        for(i=0;i<en.Length;i++){
            if(en[i].gameObject.activeSelf){
                en[i].recibeEstado("congelado",1);
                en[i].recibeEstado("quemado",1);
            }
        }
        

    }
    public void regeneracion()
    {
        int disminuye = (int)(0.02 * hp);
        cambiaHp(disminuye, 't');
        recibeEstado("habregeneracion", 4);
        eliminaEstado("quemado");
        eliminaEstado("envenenado");
        eliminaEstado("congelado");
        eliminaEstado("fatigado");
        eliminaEstado("corroido");
        eliminaEstado("enrabietado");
        eliminaEstado("asustado");
        eliminaEstado("confundido");
        eliminaEstado("cegado");
        eliminaEstado("enamorado");
        eliminaEstado("herido");
    }
    public void aCenar(npc n1)
    {
        int aumenta = (int)(hp * 0.2);
        recibeEstado("habcenar", 3);
        if (n1.getHper() <= 30)
        {
            cambiaHp(aumenta, 'c');
            devorar();
            n1.cambiaHp(n1.getHp(), 't');
        }
    }

    public void golpeTemblor(npc[] en)
    {
        int disminuye = (int)(0.4 * hp);
        cambiaHp(disminuye, 't');
        recibeEstado("habtemblor", 3);
        int dano = (int)(5 * ad);
        int i;
        
        for(i=0;i<en.Length;i++){
            float posibilidades = UnityEngine.Random.RandomRange(0.0f, 1.0f);
            if(en[i].gameObject.activeSelf&& posibilidades>=0.75f)
                en[i].cambiaHp(dano,'f');
        }
        
    }

    public void mocotralleta(npc[] en)
    {
        int dan = (int)(0.4 * ad);
        int i;
        int j;
        recibeEstado("habmetralleta", 5);
       
        int disminuye = (int)(0.1 * hp);
        cambiaHp(disminuye, 't');
       
        for (i = 0; i < 10; i++)
        {
            int eleccion = UnityEngine.Random.RandomRange(0, 4);
            for(j=0;j<en.Length;j++){
                if(en[i].gameObject.activeSelf&&eleccion==j)
                    en[i].cambiaHp(dan,'t');
            }
            
        }
              


    }
}  
