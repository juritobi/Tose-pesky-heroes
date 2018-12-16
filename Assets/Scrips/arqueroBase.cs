using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class arqueroBase : npc
{
    protected override void Start()
    {

        mhp = 150;
        iad = 80;
        iap = 0;
        idef = 20;
        imr = 10;
        base.Start();
    }
    public void decision()
    {
        personaje objetivo = FindObjectOfType<ReySlime>();
        System.Random rnd = new System.Random();
        int value = rnd.Next(1, 100);
        if(activo==true){

        if (value < 10)
        {
            System.Random rand = new System.Random();
            int valor = rand.Next(1, 100);
            if (valor < 50) { 

                objetivo.recibeEstado("ceguera",1);
            }
            Debug.Log("ceguera");
        }
        else if (value < 20)
        {
            objetivo.cambiaHp((int)Math.Round(ad * 1.1, 0),'f');
            System.Random rand = new System.Random();
            int valor = rand.Next(1, 100);
            if (valor <50)
            {
                objetivo.recibeEstado("veneno", 5);
            }
            Debug.Log("veneno");
        }
        else if (value < 40)
        {
            objetivo.cambiaHp(ad * 2,'f');
            Debug.Log("ataque doble");
        }
        else
        {
            objetivo.cambiaHp(ad,'f');
            Debug.Log("arquero basico");
        }
        animator.transform.GetChild(0).GetComponent<Animator>().Play("arquero", -1, 0);
        }
        else
        Debug.Log("estoy congelado");
    }


}
