using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReySlime : personaje {

	// Use this for initialization
	protected override void Start () {
        mhp = 1500;
        iad = 90;
        iap = 0;
        idef = 200;
        imr = 50;
        base.Start();

    }
	
    public void pasiva(npc n1,npc n2,npc n3,npc n4, npc n5)
    {
        int dan = (int)(0.1*ad);

        List<int> respuesta = new List<int>();

        if (n1.getDead() == false)
            respuesta.Add(1);
        if (n2.getDead() == false)
            respuesta.Add(2);
        if (n3.getDead() == false)
            respuesta.Add(3);
        if (n4.getDead() == false)
            respuesta.Add(4);
        if (n5.getDead() == false)
            respuesta.Add(5);

        int eleccion = UnityEngine.Random.RandomRange(0, respuesta.Count);

        if (respuesta[eleccion]==1)
        {
            n1.cambiaHp(dan, 'f');
        }
       else if (respuesta[eleccion] == 2)
        {
            n2.cambiaHp(dan, 'f');
        }
       else if (respuesta[eleccion] == 3)
        {
            n3.cambiaHp(dan, 'f');
        }
       else if (respuesta[eleccion] == 4)
        {
            n4.cambiaHp(dan, 'f');
        }
       else if (respuesta[eleccion] == 5)
        {
            n5.cambiaHp(dan, 'f');
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
        n1.cambiaHp(ad, 'f');
        n1.recibeEstado("congelado", 1);
    }
    public void lluviaAcida(npc n1,npc n2,npc n3,npc n4,npc n5)
    {
        int disminuye = (int)(0.07 * hp);
        cambiaHp(disminuye, 't');
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
        recibeEstado("regenera", 3);
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
    public void aCenar(npc n1,npc n2,npc n3,npc n4,npc n5)
    {
        int aumenta = (int)(hp * 0.3);
        if (n1.getHper() <= 30)
        {
            cambiaHp(aumenta, 'c');
        }
        else if (n2.getHper() <= 30)
        {
            cambiaHp(aumenta, 'c');
        }
       else if (n3.getHper() <= 30)
        {
            cambiaHp(aumenta, 'c');
        }
       else if (n4.getHper() <= 30)
        {
            cambiaHp(aumenta, 'c');
        }
       else if (n5.getHper() <= 30)
        {
            cambiaHp(aumenta, 'c');
        }
    }

    public void golpeTemblor(npc n1,npc n2,npc n3,npc n4,npc n5)
    {
        int disminuye = (int)(0.4 * hp);
        cambiaHp(disminuye, 't');
        int dano = (int)(6 * ad);
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
        List<int> respuesta = new List<int>();
        int disminuye = (int)(0.1 * hp);
        cambiaHp(disminuye, 't');
        if (n1.getDead() == false)
            respuesta.Add(1);
        if (n2.getDead() == false)
            respuesta.Add(2);
        if (n3.getDead() == false)
            respuesta.Add(3);
        if (n4.getDead() == false)
            respuesta.Add(4);
        if (n5.getDead() == false)
            respuesta.Add(5);

        int eleccion = UnityEngine.Random.RandomRange(0, 2);

        if (respuesta[eleccion] == 1)
        {
            for (i = 0; i < 10; i++)
            {
                n1.cambiaHp(dan, 't');
            }
        }
        else if (respuesta[eleccion] == 2)
        {
            for (i = 0; i < 10; i++)
            {
                n2.cambiaHp(dan, 't');
            }
        }
        else if (respuesta[eleccion] == 3)
        {
            for (i = 0; i < 10; i++)
            {
                n3.cambiaHp(dan, 't');
            }
        }
        else if (respuesta[eleccion] == 4)
        {
            for (i = 0; i < 10; i++)
            {
                n4.cambiaHp(dan, 'f');
            }
        }
        else if (respuesta[eleccion] == 5)
        {
            for (i = 0; i < 10; i++)
            {
                n5.cambiaHp(dan, 'f');
            }
        }


    }
}  
