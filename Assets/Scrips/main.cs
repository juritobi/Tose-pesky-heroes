using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using System;
using TMPro;

public class main : MonoBehaviour
{
    public personaje player;

    //public Object[] heroes= FindObjectsOfType(Type hero);

    public arqueroBase dps;
    public tankBase tank;
    public healerBase healer;
    public espadachinBase espadachin;
    public magoBase mago;

    public npc[] all;

    public Button Accion1;
    public Button Accion2;
    public Button Accion3;
    public Button Accion4;
    public Button Accion5;
    public Button Accion6;


    public GameObject DefeatScreen;
    public GameObject VictoryScreen;
    public GameObject Interface;
    public GameObject MenuPause;

 

    

   

    public bool paused = false;
    bool OneCoolDown = true;




    public enum BattleStates
    {
        ENEMYC,
        PLAYER1C,
        PLAYER2C,
        PLAYER3C,
        PLAYER4C,
        PLAYER5C,
        DEFEAT,
        VICTORY
    }

    private BattleStates currentState;

    // Use this for initialization
    void Start()
    {
        MenuPause.SetActive(true);
        all = FindObjectsOfType<npc>();

        currentState = BattleStates.ENEMYC;

        Accion1.onClick.AddListener(AccionA);
        Accion2.onClick.AddListener(AccionB);
        Accion3.onClick.AddListener(AccionC);
        Accion4.onClick.AddListener(AccionD);
        Accion5.onClick.AddListener(AccionE);
        Accion6.onClick.AddListener(AccionF);


    }

    // Update is called once per frame
    void Update()
    {
      
        if (player.getDead())
        {
            currentState = BattleStates.DEFEAT;
        }
        if (AllTargetsDestroyed())
        {
            currentState = BattleStates.VICTORY;
        }
        switch (currentState)
        {

            case (BattleStates.ENEMYC):

                //  Reialm of the lazy ctrl-c ctrl-v 
                //  Debug.Log(OneCoolDown);
                if (OneCoolDown)
                {
                    Debug.Log(OneCoolDown);
                    player.restaCooldowns();
                    OneCoolDown = false;
                }
                



                paused = false;
                break;

            case (BattleStates.PLAYER1C):
                
                if (tank.getDead())
                {
                    tank.clicked = false;
                    currentState = BattleStates.PLAYER2C;
                    paused = true;
                }
                else if (!paused)
                {
                    StartCoroutine(waiter());
                     tank.decision();
                    tank.restaCooldowns();
                   
                    paused = true;
                }
                break;

            case (BattleStates.PLAYER2C):
                if (dps.getDead())
                {

                    currentState = BattleStates.PLAYER3C;
                    paused = false;
                }
                else if (paused)
                {
                     dps.decision();
                    dps.restaCooldowns();                   
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
                      healer.decision();
                    healer.restaCooldowns();                  
                    StartCoroutine(waiter());
                    paused = true;
                }
                break;
            case (BattleStates.PLAYER4C):
                if (espadachin.getDead())
                {
                    currentState = BattleStates.PLAYER5C;
                    paused = false;
                }
                else if (paused)
                {
                     espadachin.decision();
                    espadachin.restaCooldowns();                   
                    StartCoroutine(waiter());

                    paused = false;
                }
                break;
            case (BattleStates.PLAYER5C):
                if (mago.getDead())
                {
                    currentState = BattleStates.ENEMYC;
                    paused = true;
                }
                else if (!paused)
                {
                    mago.decision();
                    mago.restaCooldowns();                    
                    StartCoroutine(waiter());
                    paused = true;
                }
                
                BlockButtons(true);
                OneCoolDown = true;


                break;

            case (BattleStates.VICTORY):    //  implementar plss

                //  Mostrar pantalla de victoria
                //  Recargar los npcs
                VictoryScreen.SetActive(true);
                Interface.SetActive(false);


                break;

            case (BattleStates.DEFEAT):     //  implementar plss


                DefeatScreen.SetActive(true);
                Interface.SetActive(false);
                //  Mostrar pantalla derrota
                //  Ir al menu principal

                break;

        }

        //ataque.onClick.AddListener(ataqueClick);
    }

    void BlockButtons(bool b)
    {
        Accion1.interactable = b;
        Accion2.interactable = b;
        Accion3.interactable = b;
        Accion4.interactable = b;
        Accion5.interactable = b;
        Accion6.interactable = b;
    }





    //  clicked seleccionado
   public void AccionA()
    {
        Boolean ActionDone = false;

        if (currentState == BattleStates.ENEMYC)
        {

            npc Target = null;

            for (int i = 0; i < all.Length; i++)
            {
                if (all[i].clicked)
                {
                    Target = all[i];

                }
            }
            if (Target != null)
            {
                if (tank.getDead())
                {
                    //  aqui va lo que quiera que haga el moco
                    if (player is ReySlime)
                    {
                        ReySlime moco = (ReySlime)player;
                        moco.disparoMoco(Target);
                        ActionDone = true;

                    }

                    //  all[Target].cambiaHp(10000, 'f');                  

                }
                else
                {
                    if (Target is tankBase)
                    {
                        //  aqui va lo que quiera que haga el moco
                        if (player is ReySlime)
                        {
                            ReySlime moco = (ReySlime)player;
                            moco.disparoMoco(Target);
                            ActionDone = true;

                        }
                    }
                }
                if (ActionDone)
                {
                    BlockButtons(false);
                    //   player.restaCooldowns();
                    StartCoroutine(waiter());
                }
               

            }

            for (int i = 0; i < all.Length; i++)
            {
                all[i].clicked = false;
            }
        }
    }

    void AccionB()  //  Lluvia Acida (5 adversarii)
    {
        bool ActionDone = false;
        if (currentState == BattleStates.ENEMYC)
        {
            if (player is ReySlime)
            {
                ReySlime Moco = (ReySlime)player;
                if (!player.estados.Contains("hablluvia")) {
                    Moco.lluviaAcida(all);
                    ActionDone = true;
                }
            }

            if (ActionDone)
            {
                BlockButtons(false);
                // player.restaCooldowns();
                StartCoroutine(waiter());

            }
           

        }

        for (int i = 0; i < all.Length; i++)
        {
            all[i].clicked = false;
        }
    }

    void AccionC()
    {
        bool ActionDone = false;

        if (currentState == BattleStates.ENEMYC)
        {
            if (player is ReySlime)
            {
                ReySlime moco = (ReySlime)player;
                if (!player.estados.Contains("habregeneracion"))
                {
                    moco.regeneracion();
                    ActionDone = true;
                }
            }
            if (ActionDone)
            {
                BlockButtons(false);
                // player.restaCooldowns();
                StartCoroutine(waiter());

            }
            
            }
            for (int i = 0; i < all.Length; i++)
            {
                all[i].clicked = false;
            }     
    }

    void AccionD()
    {
        Boolean ActionDone = false;
        if (currentState == BattleStates.ENEMYC)
        {

            npc Target = null;

            for (int i = 0; i < all.Length; i++)
            {
                if (all[i].clicked)
                {
                    Target = all[i];

                }
            }
            if (Target != null)
            {
                if (tank.getDead())
                {
                    //  aqui va lo que quiera que haga el moco
                    if (player is ReySlime)
                    {
                        ReySlime moco = (ReySlime)player;
                        if (!player.estados.Contains("habcenar")){
                            moco.aCenar(Target);
                            ActionDone = true;
                        }
                       

                    }

                    //all[Target].cambiaHp(10000, 'f');                  

                }
                else
                {
                    if (Target is tankBase)
                    {
                        //  aqui va lo que quiera que haga el moco
                        if (player is ReySlime)
                        {
                            ReySlime moco = (ReySlime)player;
                            if (!player.estados.Contains("habcenar"))
                            {
                                moco.aCenar(Target);
                                ActionDone = true;
                            }
                            

                        }
                    }
                }
                if (ActionDone)
                {
                    BlockButtons(false);
                  //  player.restaCooldowns();
                    StartCoroutine(waiter());
                }
                

            }

            for (int i = 0; i < all.Length; i++)
            {
                all[i].clicked = false;
            }
        }
    }

    void AccionE()  //  temblor wow
    {
        bool ActionDone = false;

        if (currentState == BattleStates.ENEMYC)
        {
            //  aqui va lo que quiera que haga el moco
            if (player is ReySlime)
            {
                ReySlime moco = (ReySlime)player;
                if (!player.estados.Contains("habtemblor"))
                {
                    moco.golpeTemblor(all);
                    ActionDone = true;
                }

            }
            if (ActionDone)
            {
                BlockButtons(false);
                // player.restaCooldowns();
                StartCoroutine(waiter());
            }
           

            for (int i = 0; i < all.Length; i++)
            {
                all[i].clicked = false;
            }

        }
    }

    void AccionF()
    {
        bool ActionDone = false;
       
        if (currentState == BattleStates.ENEMYC)
        {
            //  aqui va lo que quiera que haga el moco
            if (player is ReySlime)
            {
                ReySlime moco = (ReySlime)player;

                if (!player.estados.Contains("habmetralleta"))
                {
                    moco.mocotralleta(all);
                    ActionDone = true;
                }

            }

            if (ActionDone)
            {
                BlockButtons(false);
                // player.restaCooldowns();
                StartCoroutine(waiter());
            }
           


            for (int i = 0; i < all.Length; i++)
            {
                all[i].clicked = false;
            }
           
        }
    }


    bool AllTargetsDestroyed()
    {
        if (tank.getDead() && dps.getDead() && healer.getDead() && espadachin.getDead() && mago.getDead())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("_MainMenu");
    }

    public void OnVictoryChoose(int i)
    {
        switch (i)
        {
            case 0:
                player.cambiaHp(200, 'c');
                break;
            case 1:
                int num = UnityEngine.Random.Range(25,35);
                MainMenu.almas+=num;
                break;
            case 2:
                //buscar objeto
                break;
            default:
                Debug.LogError("This shouldn't be happening, but here we are...");
                break;
        }
        //   we should "respawn" enemies but we're "respawning" the scene but nobody knows heh heh heh.
        currentState = BattleStates.ENEMYC;
        Debug.Log(currentState);
        SceneManager.LoadScene("prueba");


    }
























    /* 
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
    */
    
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
            currentState = BattleStates.PLAYER5C;
        }
        else if (currentState == BattleStates.PLAYER5C)
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
