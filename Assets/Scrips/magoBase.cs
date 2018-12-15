using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class magoBase : npc
{
    protected int pasivasiono;
    protected override void Start()
    {
        
        mhp = 150;
        iad = 0;
        iap = 80;
        pasivasiono=0;
        idef = 0;
        imr = 10;
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
            if(pasivasiono==0)
            ap = (int)Math.Round(ap + iap * 1.2, 0);
            pasivasiono=1;
        }
        else
        {
            pasivasiono=0;
            ap = iap;
        }
    if(activo==true){
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
        animator.transform.GetChild(0).GetComponent<Animator>().Play("mago", -1, 0);
    }
    else
    Debug.Log("estoy congelado");
    }

    
}
