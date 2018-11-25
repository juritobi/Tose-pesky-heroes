using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class personaje : MonoBehaviour {
	public Slider barH;
	public int mhp;
	public int hp;
	public int ad;
	public int ap;
    public int def;
    public int mr;
    protected List<string> estados;
    protected List<int> cooldowns;


	// Use this for initialization
	protected virtual void Start() {
        hp = mhp;
        barH.maxValue = mhp;
		estados=new List<string>();
        cooldowns = new List<int>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
		barH.value=hp;
    }

    public void cambiaHp(int c, char tipo){//tipos: m daño magico, f daño fisico, c curacion, t daño verdadero(ignora defensas)

        if (tipo.Equals('f'))
        {
            if (c - def > 0)
            {
                hp = hp - c + def;
                if (hp < 0)
                {
                    hp = 0;
                }
            }
        }
        else if(tipo.Equals('m'))
        {
            if (c - mr > 0)
            {
                hp = hp - c + mr;
                if (hp < 0)
                {
                    hp = 0;
                }
            }
        }   
        else if (tipo.Equals('t'))
        {
            hp = hp - c;
            if (hp < 0)
            {
                hp = 0;
            }
        }
		else if(tipo.Equals('c')){
			hp=hp+c;
			if(hp>mhp){
				hp=mhp;
			}
		}
	}
    public void recibeEstado(string e,int turnos)
    {
        switch (e)
        {
            case "defensa1":
                cambiaDefensa((int)Math.Round(def * 0.3, 0));
                break;
            case "defensa2":
                cambiaDefensa((int)Math.Round(def * 0.5, 0));
                break;
            default:break;
        }
        estados.Add(e);
        cooldowns.Add(turnos);
    }
    
    public void restaCooldowns()
    {
        if (estados.Contains("veneno"))
        {
            this.cambiaHp((int) Math.Round(mhp * 0.05), 't');
        }
        for (int i =0;i< cooldowns.Count; i++)
            {
                cooldowns[i]= cooldowns[i]-1;
                
                if (cooldowns[i] == 0)
                {
                    cooldowns.RemoveAt(i);
                    eliminaEstado(estados[i]);
                }
            }
        
    }

    public void eliminaEstado(string e)
    {
        switch (e)
        {
            case "defensa1" : cambiaDefensa((int)Math.Round(-(def * 0.3), 0));
                break;
            case "defensa2": cambiaDefensa((int)Math.Round(-(def * 0.5), 0));
                break;
            default: break;
        }
        estados.Remove(e);
    }

    public int getHp()
    {
        return hp;
    }
    public float getHper()
    {
        return hp*100/mhp;
    }
    public int getMhp()
    {
        return hp;
    }

    public void cambiaDefensa(int c)
	{
			def = def + c;
	}

}
