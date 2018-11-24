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
	public npc dps; public npc tank; public npc healer;
	public npc[] all;
	public Ability[] ab;
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
		ab = FindObjectsOfType<Ability>();
		int n = ab.Length;
		currentState = BattleStates.ENEMYC;
		ataque.onClick.AddListener(ataqueClick);
		habilidad.onClick.AddListener(habilidadClick);
	}

	// Update is called once per frame
	void Update () {
		switch (currentState){
			case (BattleStates.ENEMYC):
				Debug.Log("Turno Enemigo");
				break;

			case (BattleStates.PLAYER1C):
				Debug.Log("Turno Player1");
				//tank tk = (tank) tank;
				player.cambiaHp(30);
				currentState = BattleStates.PLAYER2C;
				break;

			case (BattleStates.PLAYER2C):
				Debug.Log("Turno Player2");
                //dps dp = (dps) dps;
                player.cambiaHp(300);
                currentState = BattleStates.PLAYER3C;
				break;

			case (BattleStates.PLAYER3C):
				Debug.Log("Turno Player3");
                //healer hl = (healer) healer;
                all[0].cambiaHp(-5);
                currentState = BattleStates.ENEMYC;
				checkCd(ab);
				break;
		}
		//ataque.onClick.AddListener(ataqueClick);
	}
	void ataqueClick(){
		if(currentState==BattleStates.ENEMYC){
			foreach (npc h in all) {
				if(h.clicked==true){
                    h.cambiaHp(25);
                    Debug.Log(h);
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
                    h.cambiaHp(50);
                    foreach (npc h2 in all) {
						h2.clicked=false;
					}
					currentState = BattleStates.PLAYER1C;
				}
			}
		}
	}

	void checkCd(Ability[] abs){
		foreach (Ability a in abs) {
			if(a.coolDown>0){
				a.coolDown-=1;
			}
		}
	}
	IEnumerator waiter(){
		yield return new WaitForSeconds(15);
	}
}
