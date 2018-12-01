using System.Collections;
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
	
   

    public void salpicar(npc n1,npc n2,npc n3,npc n4, npc n5,int dan)

    {
        int dandiv = (int)(0.1*dan);

        if ( n1.getDead()==false)
            n1.cambiaHp(dandiv, 't');

        if (n2.getDead() == false)
            n2.cambiaHp(dandiv, 't');
        if (n3.getDead() == false)
            n3.cambiaHp(dandiv, 't');
        if (n4.getDead() == false)
            n4.cambiaHp(dandiv, 't');
        
        


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
    public void lluviaAcida(npc n1,npc n2,npc n3,npc n4,npc n5)
    {
        int disminuye = (int)(0.07 * hp);
        cambiaHp(disminuye, 't');
        recibeEstado("hablluvia", 2);
        n1.recibeEstado("congelado", 1);
        n1.recibeEstado("quemado", 1);
        n2.recibeEstado("congelado", 1);
        n2.recibeEstado("quemado", 1);
        n3.recibeEstado("congelado", 1);
        n3.recibeEstado("quemado", 1);
        n4.recibeEstado("congelado", 1);
        n4.recibeEstado("quemado", 1);
        n5.recibeEstado("congelado", 1);
        n5.recibeEstado("quemado", 1);

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

    public void golpeTemblor(npc n1,npc n2,npc n3,npc n4,npc n5)
    {
        int disminuye = (int)(0.4 * hp);
        cambiaHp(disminuye, 't');
        recibeEstado("habtemblor", 3);
        int dano = (int)(5 * ad);
        float posibilidades = UnityEngine.Random.RandomRange(0.0f, 2.0f);
        if (posibilidades >= 0.75f)
        {
            n1.cambiaHp(dano, 'f');
        }

        posibilidades = UnityEngine.Random.RandomRange(0.0f, 2.0f);
        if (posibilidades >= 0.75f)
        {
            n2.cambiaHp(dano, 'f');
        }

        posibilidades = UnityEngine.Random.RandomRange(0.0f, 2.0f);
        if (posibilidades >= 0.75f)
        {
            n3.cambiaHp(dano, 'f');
        }

        posibilidades = UnityEngine.Random.RandomRange(0.0f, 2.0f);
        if (posibilidades >= 0.75f)
        {
            n4.cambiaHp(dano, 'f');
        }

        posibilidades = UnityEngine.Random.RandomRange(0.0f, 2.0f); ;
        if (posibilidades >= 0.75f)
        {
            n5.cambiaHp(dano, 'f');
        }
    }

    public void mocotralleta(npc n1,npc n2,npc n3,npc n4,npc n5)
    {
        int dan = (int)(0.4 * ad);
        int i;
        recibeEstado("habmetralleta", 5);
       
        int disminuye = (int)(0.1 * hp);
        cambiaHp(disminuye, 't');
       
        for (i = 0; i < 10; i++)
        {
            int eleccion = UnityEngine.Random.RandomRange(1, 5);
            if (eleccion == 1 && n1.getDead() == false)
                n1.cambiaHp(dan, 't');
            if (eleccion==2 && n2.getDead() == false)
                n2.cambiaHp(dan, 't');
            if (eleccion==3 && n3.getDead() == false)
                n3.cambiaHp(dan, 't');
            if (eleccion==4 && n4.getDead() == false)
                n4.cambiaHp(dan, 't');
            if (eleccion==5 && n5.getDead() == false)
                n5.cambiaHp(dan, 't');
        }
              


    }
}  
