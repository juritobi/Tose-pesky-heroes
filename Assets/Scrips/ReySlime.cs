using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReySlime : personaje {
    public GameObject disparo;
	// Use this for initialization
	protected override void Start () {

        mhp = 2000;
        iad = 50;
        iap = 80;
        idef = 20;
        imr = 10;
        
        
        base.Start();

    }
	
   

    public void salpicar(int dan)

    {
        npc[] all = FindObjectsOfType<npc>();
        int dandiv = (int)(0.2*dan);
        int i;
        for(i=0;i<all.Length;i++){
            if(all[i].gameObject.activeSelf)
              all[i].cambiaHp(dandiv,'t');
        }

        Debug.Log("salpicar");

    }
    public void devorar()
    {
        int aumenta = (int)(0.1 * mhp);
        cambiaHp(aumenta, 'c');
        Debug.Log("devorar");
       
        
    }
    public void disparoMoco(npc n1)
    {
        int disminuye = (int)(0.03 * mhp);
        cambiaHp(disminuye, 't');
        n1.cambiaHp(ap, 'm');
        n1.recibeEstado("congelado", 1);

        animacionAtaque("disparomoco");
        salpicar(ap - n1.getMr());
        Debug.Log("disparomoco");
    }
    public void lluviaAcida(npc[] en)
    {
        int disminuye = (int)(0.07 * mhp);
        cambiaHp(disminuye, 't');
        recibeEstado("hablluvia", 2);
        int i;
        for(i=0;i<en.Length;i++){
            if(en[i].gameObject.activeSelf){
                en[i].recibeEstado("congelado",1);
                en[i].recibeEstado("quemado",1);
            }
        }
        animacionAtaque("lluvia");
        Debug.Log("lluvia acida");


    }
    public void regeneracion()
    {
        int disminuye = (int)(0.2 * mhp);
        cambiaHp(disminuye, 'c');
        recibeEstado("habregeneracion", 4);
        //devorar();
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
        Debug.Log("regeneracion");
    }
    public void aCenar(npc n1)
    {
        int aumenta = (int)(mhp * 0.2);
        recibeEstado("habcenar", 3);
        if (n1.getHper() <= 30)
        {
            cambiaHp(aumenta, 'c');
            devorar();
            n1.cambiaHp(n1.getHp(), 't');
        }
        else
        {
            disparoMoco(n1);
        }
        Debug.Log("a cenar");
    }

    public void golpeTemblor(npc[] en)
    {
        int disminuye = (int)(0.2 * mhp);
        cambiaHp(disminuye, 't');
        recibeEstado("habtemblor", 3);
        int dano = (int) (1.5 * ad);
        int i;
        
        for(i=0;i<en.Length;i++){
            float posibilidades = UnityEngine.Random.RandomRange(0.0f, 1.0f);
            if(en[i].gameObject.activeSelf&& posibilidades>=0.75f)
                en[i].cambiaHp(dano,'f');
        }
        Debug.Log("golpe temblor");
    }

    public void mocotralleta(npc[] en)
    {
        int dan = (int)(0.4 * ad);
        int i;
        recibeEstado("habmetralleta", 5);
       
        int disminuye = (int)(0.1 * mhp);
        cambiaHp(disminuye, 't');
        int eleccion = 0;
        for (i = 0; i < 11; i++)
        {
            eleccion = UnityEngine.Random.RandomRange(0, 5);
             en[eleccion].cambiaHp(dan,'t');
        }
        animacionAtaque("mocotralleta");
        Debug.Log("mocotralleta");

    }
    public void animacionAtaque(string animacion)
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        var go = Instantiate(disparo, pos, Quaternion.identity, transform);
        go.GetComponent<Animator>().Play(animacion, -1, 0);
        Destroy(go, 1);
    }
}  
