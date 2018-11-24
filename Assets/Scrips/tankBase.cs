using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tankBase : npc
{
    private void Start()
    {
        mhp = 300;
        ad = 50;
        ap = 0;
        def = 10;
        mr = 50;
    }
    public void decision()
    {
        System.Random rnd = new System.Random();
        int value = rnd.Next(1, 100);

        if (value < 10)
        {
            //int aliado= rnd.Next(0, all.length);
            //aply estado DEFENSA2
        }
        else if (value < 30)
        {
            //this.aplica DEFENSA1;
        }
        else if (value < 60)
        {
            //jugador.cambiaHp(def)
        }
        else
        {

        }
    }


}
