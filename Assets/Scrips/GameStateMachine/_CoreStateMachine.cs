using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class _CoreStateMachine : MonoBehaviour {

    public enemy_health Enemy,Enemy2;
    public player_health Player;
    public TMP_Text StateOfResult;
    public GameObject endScreen;
    public GameObject mainScreen;
   

    private bool gameOver = false;
    private bool Player_turn = false;
   
    public enum BattleStates
    {
        BEGIN,
        PLAYERCHOICE,
        ENEMYCHOICE,
        DEFEAT,
        VICTORY
    }

    private BattleStates currentState;
	// Use this for initialization
	void Start () {
        currentState = BattleStates.BEGIN;
        StateOfResult.gameObject.SetActive(false);
        endScreen.SetActive(false);
        
        

	}
	
	// Update is called once per frame
	void Update () {
		
        switch (currentState)
        {
            case (BattleStates.BEGIN):
                //currentState = (BattleStates)(((int)currentState + 1)%5);
                Player_turn = true;
                currentState = BattleStates.PLAYERCHOICE;
                


                Debug.Log("begin");
                break;
            case (BattleStates.PLAYERCHOICE):
                
                Debug.Log("player");
                break;
            case (BattleStates.ENEMYCHOICE):
                Player.TakeDamage(10);

                if (Player.getHp() <= 0)
                {
                    currentState = BattleStates.DEFEAT;
                }
                else if (Enemy.getHp() <= 0)
                {
                    currentState = BattleStates.VICTORY;
                    
                }
                else
                {
                    currentState = BattleStates.BEGIN;
                }               
                Debug.Log("enemy");
                break;
            case (BattleStates.DEFEAT):
                StateOfResult.text = "#99 VICTORYN'T ROYALE";
                FinnishGame();

                Debug.Log("defeat");
                break;
            case (BattleStates.VICTORY):                
                StateOfResult.text = "#1 VICTORY ROYALE";
                FinnishGame();


                Debug.Log("wictory");
                break;
        }
	}

    public void Onclick(string type)
    {
        if (!gameOver && Player_turn)
        {
            if (type == "magic")
            {
                if (Player.getMp() >= 60)
                {
                    Player.Usemp(60);
                    Enemy.takeDamage(Player.damageattack1());
                    Enemy2.takeDamage(60);
                    Debug.Log("magic");
                    currentState = BattleStates.ENEMYCHOICE;
                }
                else
                {
                    currentState = BattleStates.PLAYERCHOICE;
                    Debug.Log("playerchoice no mana");
                }
                


            }
            else if (type == "melee")
            {
                Enemy.takeDamage(0);
                Enemy2.takeDamage(60);
                Debug.Log("melee");

                currentState = BattleStates.ENEMYCHOICE;
            }
            else if (type == "recover")
            {
                Player.TakeDamage(Player.getHp() - Player.getMaxHp());
                Player.Usemp(Player.getMp() - Player.getMaxMp());
            }
            else if (type == "objeto")
            {
                Player.TakeDamage(Player.getHp() - Player.getMaxHp());
                Player.Usemp(Player.getMp() - Player.getMaxMp());
            }
            //currentState = (BattleStates)(((int)currentState + 1)%5);
            Player_turn = false;

        }


    }
    void FinnishGame ()
    {
        mainScreen.SetActive(false);
        StateOfResult.gameObject.SetActive(true);        
        endScreen.SetActive(true);
        gameOver = true;
    }

    
   
}
