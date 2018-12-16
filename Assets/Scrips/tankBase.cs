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
        iad = 50;
        iap = 0;
        idef = 40;
        imr = 20;
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
        animator.transform.GetChild(0).GetComponent<Animator>().Play("tank", -1, 0);
        }
    else 
        Debug.Log("estoy congelado");
    }
  
    
}
