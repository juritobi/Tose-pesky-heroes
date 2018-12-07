using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckClicked : MonoBehaviour {

    public arqueroBase dps; public tankBase tank; public healerBase healer; public espadachinBase espadachin;
    public bool D, T, H, E;

    // Use this for initialization
    void Start () {
       
        
    }
	
	// Update is called once per frame
	void Update () {
        D = dps.clicked;
        T = tank.clicked;
        H = healer.clicked;
        E = espadachin.clicked;

    }
    public void Check(npc click)
    {
        if (click is arqueroBase)
        {
            tank.clicked = false;
            healer.clicked = false;
            espadachin.clicked = false;

        }
        if (click is tankBase)
        {
            dps.clicked = false;
            healer.clicked = false;
            espadachin.clicked = false;
        }
        if (click is healerBase)
        {
            dps.clicked = false;
            tank.clicked = false;
            espadachin.clicked = false;
        }
        if (click is espadachinBase)
        {
            dps.clicked = false;
            tank.clicked = false;
            healer.clicked = false;
        }
    }
}
