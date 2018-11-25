using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tankBase : npc
{
    protected override void Start()
    {

        mhp = 300;
        ad = 50;
        ap = 0;
        def = 100;
        mr = 50;
        base.Start();
    }
    public void decision()
    {
         
        if (estados.Contains("ceguera") && Random.Range(0,1)==1){

        }
        else
        {
            personaje objetivo = FindObjectOfType<jugador>();
            System.Random rnd = new System.Random();
            int value = rnd.Next(1, 100);

            if (value < 10)
            {
                Debug.Log("detras de mi");
                npc[] aux = FindObjectsOfType<npc>();
                do
                {
                    objetivo = aux[Random.Range(0, aux.Length)];
                } while (objetivo == this);
                objetivo.recibeEstado("defensa2", 3);
            }
            else if (value < 30)
            {
                Debug.Log("defender");
                this.recibeEstado("defensa1", 2);
            }
            else if (value < 60)
            {
                Debug.Log("golpe de escudo");
                objetivo.cambiaHp(def, 'f');
            }
            else
            {
                Debug.Log("tank basico");
                objetivo.cambiaHp(ad, 'f');
            }
        }
    }
    
}
