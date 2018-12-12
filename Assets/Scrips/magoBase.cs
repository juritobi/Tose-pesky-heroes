using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class magoBase : npc
{
    protected override void Start()
    {

        mhp = 175;
        iad = 0;
        iap = 120;
        idef = 25;
        imr = 45;
        base.Start();
    }
    public void decision()
    {
        Debug.Log("soy un mago");
        personaje objetivo = FindObjectOfType<ReySlime>();
        System.Random rnd = new System.Random();
        int value = rnd.Next(1, 100);

        if (hp == mhp)
        {
            ap = (int)Math.Round(ap + iap * 1.2, 0);
        }
        else
        {
            ap = iap;
        }

        if (value < 20)
        {
            objetivo.cambiaHp((int)Math.Round(ap * 1.2, 0), 'm');
            Debug.Log("Bola magica");
        }
        else if (value < 30)
        {
            objetivo.cambiaHp((int)Math.Round(ap -0.5 * objetivo.getMr(), 0), 't');
            Debug.Log("perforar");
        }
        else if (value < 36)
        {
            objetivo.cambiaHp((int)Math.Round(ap * 1.3-objetivo.getMr(), 0), 't');
            cambiaHp((int)Math.Round((ap * 1.3 - objetivo.getMr())/2, 0), 'c');
            Debug.Log("drenar");
        }
        else
        {
            objetivo.cambiaHp(ap,'m');
            Debug.Log("mago basico");
        }
    }


}
