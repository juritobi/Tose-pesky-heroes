﻿using System.Collections;
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
	public npc dps; public npc tank; public npc healer;
	public npc[] all;
	public Button ataque;
	public Button habilidad;

	public enum BattleStates
    {
        ENEMYC,
        PLAYER1C,
        PLAYER2C,
        PLAYER3C,
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
				break;

			case (BattleStates.PLAYER1C):
                tankBase tk = (tankBase)tank;
                tk.decision();
                tk.restaCooldowns();
				currentState = BattleStates.PLAYER2C;
				break;

			case (BattleStates.PLAYER2C):
                arqueroBase dp = (arqueroBase)dps;
                dp.decision();
                dp.restaCooldowns();
                currentState = BattleStates.PLAYER3C;
				break;

			case (BattleStates.PLAYER3C):
                healerBase h = (healerBase)healer;
                h.decision();
                h.restaCooldowns();
                currentState = BattleStates.ENEMYC;
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
                    currentState = BattleStates.PLAYER1C;
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
                    currentState = BattleStates.PLAYER1C;
				}
			}
		}
	}
	IEnumerator waiter(){
		yield return new WaitForSeconds(15);
	}
}
