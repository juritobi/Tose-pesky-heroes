using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class main : MonoBehaviour {
	public enemy enemigo;
	//public Object[] heroes= FindObjectsOfType(Type hero);
	public hero heroe1; public hero heroe2; public hero heroe3;
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
				//StartCoroutine(waiter());
				waiter();
				heroe1.attack(enemigo,2);
				currentState = BattleStates.PLAYER2C;
				break;

			case (BattleStates.PLAYER2C):
				Debug.Log("Turno Player2");
				heroe2.attack(enemigo,1);
				currentState = BattleStates.PLAYER3C;
				break;

			case (BattleStates.PLAYER3C):
				Debug.Log("Turno Player3");
				heroe3.attack(enemigo,1);
				currentState = BattleStates.ENEMYC;
				break;
		}
		//ataque.onClick.AddListener(ataqueClick);
	}
	void ataqueClick(){
		if(currentState==BattleStates.ENEMYC){
			if(heroe1.clicked==true){
				enemigo.attack(heroe1,1);
				heroe1.clicked=false;
				heroe2.clicked=false;
				heroe3.clicked=false;
				currentState = BattleStates.PLAYER1C;
			}

			if(heroe2.clicked==true){
				enemigo.attack(heroe2,1);
				heroe1.clicked=false;
				heroe2.clicked=false;
				heroe3.clicked=false;
				currentState = BattleStates.PLAYER1C;
			}

			if(heroe3.clicked==true){
				enemigo.attack(heroe3,1);
				heroe1.clicked=false;
				heroe2.clicked=false;
				heroe3.clicked=false;
				currentState = BattleStates.PLAYER1C;
			}
		}
	}

	void habilidadClick(){
		if(currentState==BattleStates.ENEMYC){
			if(heroe1.clicked==true){
				enemigo.attack(heroe1,2);
				heroe1.clicked=false;
				heroe2.clicked=false;
				heroe3.clicked=false;
				currentState = BattleStates.PLAYER1C;
			}

			if(heroe2.clicked==true){
				enemigo.attack(heroe2,2);
				heroe1.clicked=false;
				heroe2.clicked=false;
				heroe3.clicked=false;
				currentState = BattleStates.PLAYER1C;
			}

			if(heroe3.clicked==true){
				enemigo.attack(heroe3,2);
				heroe1.clicked=false;
				heroe2.clicked=false;
				heroe3.clicked=false;
				currentState = BattleStates.PLAYER1C;
			}
		}
	}
	IEnumerator waiter(){
		yield return new WaitForSeconds(15);
	}
}
