using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class espadachinBase : npc
{
    protected override void Start()
    {

        mhp = 250;
        iad = 120;
        iap = 0;
        idef = 60;
        imr = 10;
        base.Start();
    }
    public void decision()
    {
        if (getHper() < 30)
        {
            recibeEstado("ataque1", 3);
        }
        personaje objetivo = FindObjectOfType<ReySlime>();
        System.Random rnd = new System.Random();
        int value = rnd.Next(1, 100);

        if (value < 6)
        {
            objetivo.cambiaHp((int)Math.Round((ad * 1.5 - objetivo.getDef()) *mhp/hp, 0), 't');
            cambiaHp(mhp, 't');
            Debug.Log("estocada final");
        }
        else if (value < 16)
        {
            objetivo.cambiaHp((int)Math.Round(ad * 1.5, 0), 'f');
            cambiaHp((int)Math.Round((ad * 1.5 - objetivo.getDef()) /2, 0), 't');

            Debug.Log("carga");
        }
        else if (value < 36)
        {
            recibeEstado("ataque1", 3);
            Debug.Log("preparacion");
        }
        else
        {
            objetivo.cambiaHp(ad, 'f');
            Debug.Log("espadachin basico");
        }
    }


}