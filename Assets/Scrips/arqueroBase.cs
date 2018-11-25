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

        mhp = 200;
        ad = 80;
        ap = 0;
        def = 75;
        mr = 45;
        base.Start();
    }
    public void decision()
    {
        personaje objetivo = FindObjectOfType<jugador>();
        System.Random rnd = new System.Random();
        int value = rnd.Next(1, 100);

        if (value < 10)
        {
            objetivo.cambiaHp((int)Math.Round(ad * 1.1, 0),'f');
            value = rnd.Next(0, 1);
            if (value == 1)
            {
                objetivo.recibeEstado("ceguera",1);
            }
            Debug.Log("ceguera");
        }
        else if (value < 20)
        {
            objetivo.cambiaHp((int)Math.Round(ad * 1.1, 0),'f');
            value = rnd.Next(0, 1);
            if (value == 1)
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
    }


}
