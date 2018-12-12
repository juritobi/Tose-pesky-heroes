using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class healerBase : npc
{
    protected override void Start()
    {
        mhp = 180;
        iad = 0;
        iap = 50;
        idef = 55;
        imr = 95;
        base.Start();
    }
    public void decision()
    {
        personaje objetivo = FindObjectOfType<ReySlime>();
        System.Random rnd = new System.Random();
        int value = rnd.Next(1, 100);

        if (value < 6)
        {
            objetivo.cambiaHp((int)Math.Round(ap * 1.5,0) , 'm');
            Debug.Log("ataque magico");
        }
        else if (value < 17)
        {
            objetivo = null;
            npc[] aux = FindObjectsOfType<npc>();
            foreach (npc o in aux)
            {
                o.cambiaHp((int)Math.Round(o.getMhp() * 0.3, 0), 'c');
            }
            Debug.Log("curacion all");
        }
        else if (value < 27)
        {
            objetivo = null;
            npc[] aux = FindObjectsOfType<npc>();
            foreach (npc o in aux)
            {
                if (objetivo == null || o.getHper() < objetivo.getHper())
                {
                    objetivo = o;
                }
            }
            objetivo.cambiaHp((int)Math.Round(objetivo.getMhp() * 0.5), 'c');
            Debug.Log("curacion grande");
        }
        else if (value < 60)
        {
            objetivo = null;
            npc[] aux = FindObjectsOfType<npc>();
            foreach (npc o in aux)
            {
                if (objetivo == null || o.getHper() < objetivo.getHper())
                {
                    objetivo = o;
                }
            }
            objetivo.cambiaHp((int)Math.Round(objetivo.getMhp() * 0.3), 'c');
            Debug.Log("curacion pequeña");
        }
        else
        {
            objetivo.cambiaHp(ap, 'm');
            Debug.Log("healer basico");
        }
        animator.transform.GetChild(0).GetComponent<Animator>().Play("heal", -1, 0);
    }


}
