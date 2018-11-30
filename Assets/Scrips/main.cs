using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using System;
using TMPro;

public class main : MonoBehaviour {
	public personaje player;
	//public Object[] heroes= FindObjectsOfType(Type hero);
	public arqueroBase dps; public tankBase tank; public healerBase healer;public espadachinBase espadachin;
	public npc[] all;
	public Button ataque;
	public Button habilidad;
    public bool paused = false;

	public enum BattleStates
    {
        ENEMYC,
        PLAYER1C,
        PLAYER2C,
        PLAYER3C,
        PLAYER4C,
        VICTORY
    }

	private BattleStates currentState;

	// Use this for initialization
	void Start () {
        all = FindObjectsOfType<npc>();
		currentState = BattleStates.ENEMYC;
		ataque.onClick.AddListener(ataqueClick);
		habilidad.onClick.AddListener(habilidadClick);
	}

	// Update is called once per frame
	void Update () {
		switch (currentState){
			case (BattleStates.ENEMYC):
                paused = false;
				break;

			case (BattleStates.PLAYER1C):
                if (tank.getDead())
                {
                    currentState = BattleStates.PLAYER2C;
                    paused = true;
                }
                else if (!paused)
                {
                    StartCoroutine(waiter());
                    tank.restaCooldowns();
                    tank.decision();
                    paused = true;
                }
                break;

            case (BattleStates.PLAYER2C):
                if (dps.getDead())
                {
                    currentState = BattleStates.PLAYER3C;
                    paused=false;
                }
                else if (paused)
                {
                    dps.restaCooldowns();
                    dps.decision();
                    StartCoroutine(waiter());
                    paused = false;
                }
				break;

			case (BattleStates.PLAYER3C):
                if (healer.getDead())
                {
                    currentState = BattleStates.PLAYER4C;
                    paused = true;
                }
                else if (!paused)
                {
                    healer.restaCooldowns();
                    healer.decision();
                    StartCoroutine(waiter());
                    paused = true;
                }
				break;
            case (BattleStates.PLAYER4C):
                if (espadachin.getDead())
                {
                    currentState = BattleStates.ENEMYC;
                    paused = false;
                }
                else if (paused)
                {
                    espadachin.restaCooldowns();
                    espadachin.decision();
                    StartCoroutine(waiter());
                    
                    paused = false;
                }
                break;
        }
		//ataque.onClick.AddListener(ataqueClick);
	}
	void ataqueClick(){
		if(currentState==BattleStates.ENEMYC){
			foreach (npc h in all) {
				if(h.clicked==true){
                    h.cambiaHp(100,'f');
                    player.restaCooldowns();
                    foreach (npc h2 in all) {
						h2.clicked=false;
					}
                    StartCoroutine(waiter());
                }
			}
		}
	}

	void habilidadClick(){
		if(currentState==BattleStates.ENEMYC){
			foreach (npc h in all) {
				if(h.clicked==true){
                    h.cambiaHp(120,'m');
                    player.restaCooldowns();
                    foreach (npc h2 in all) {
						h2.clicked=false;
					}
                    StartCoroutine(waiter());
                }
			}
		}
	}
	IEnumerator waiter(){
        yield return new WaitForSeconds(1);
        if (currentState == BattleStates.ENEMYC)
        {
            currentState = BattleStates.PLAYER1C;
        }
        else if (currentState == BattleStates.PLAYER1C)
        {
            currentState = BattleStates.PLAYER2C;
        }
        else if (currentState == BattleStates.PLAYER2C)
        {
            currentState = BattleStates.PLAYER3C;
        }
        else if (currentState == BattleStates.PLAYER3C)
        {
            currentState = BattleStates.PLAYER4C;
        }
        else if (currentState == BattleStates.PLAYER4C)
        {
            currentState = BattleStates.ENEMYC;
        }
        
    }
    /*public void bucle()
{
    personaje[] personajes = FindObjectsOfType<personaje>();
    int i = 0;
    bool flag = false;
    while (true)
    {
        if (i == 0)
        {
            StartCoroutine(playerTurn());
            while (flag){}
        }
        else
        {
            npc actual=(npc)personajes[i];
            actual.GetType().InvokeMember("decision",System.Reflection.BindingFlags.InvokeMethod, null, actual, null);

        }
        i++;
    }
}*/
}
