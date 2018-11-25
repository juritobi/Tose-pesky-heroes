using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;

public class personaje : MonoBehaviour {
    public GameObject damageText;
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
        int total;
        switch (tipo)
        {
            case 'f': total = c - def;
                if (total < 0) { total = 0; }
                break;
            case 'm': total = c - mr;
                if (total < 0) { total = 0; }
                break;
            case 't': total = c;
                break;
            case 'c': total = -c;
                if (total > 0) { total = 0; }
                break;
            default:total = 0;break;
        }

        hp = hp - total;

        if (total != 0)
        {
            muestraDaño(total);
        }

        if (hp < 0)
        {
            muerto();
        }
        else if (hp > mhp)
        {
            hp = mhp;
        }

	}

    public void muestraDaño(int i)
    {
        Vector3 pos = new Vector3 (transform.position.x, transform.position.y+1, transform.position.z-1) ;
        var go=Instantiate(damageText, pos, Quaternion.identity, transform);
        if (i < 0)
        {
            go.GetComponent<TextMesh>().color = Color.green;
        }
        go.GetComponent<TextMesh>().text = i.ToString();
        
        

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

    public void muerto()
    {
        DestroyImmediate(barH.gameObject);
        DestroyImmediate(this.gameObject);
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
