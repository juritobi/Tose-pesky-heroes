using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;
public class personaje : MonoBehaviour {
    public GameObject damageText;
    public GameObject textestado;
    public List<GameObject> textestadoobj;
	public Slider barH;
    public GameObject animator;
	public int mhp;
	public int hp;
    public int iad;
    public int ad;
    public int iap;
    public int ap;
    public int idef;
    public int def;
    public int imr;
    public int mr;
    public bool dead;
    protected List<string> estados;
    protected List<int> cooldowns;


	// Use this for initialization
	protected virtual void Start() {
   
        hp = mhp;
        ad = iad;
        ap = iap;
        def = idef;
        mr = imr;
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
            animacionDaño();
        }

        if (hp <= 0)
        {
            muerto();
        }
        else if (hp > mhp)
        {
            hp = mhp;
        }

	}

    public void animacionDaño()
    {
        animator.GetComponent<Animator>().Play("recibeDaño",-1,0);
    }

    public void muestraDaño(int i)
    {
        Vector3 pos = new Vector3 (transform.position.x, transform.position.y+1, transform.position.z-1) ;
        var go=Instantiate(damageText, pos, Quaternion.identity, transform);
        if (i < 0)
        {
            go.GetComponent<TextMesh>().color = Color.green;
            i = -i;
        }
        go.GetComponent<TextMesh>().text = i.ToString();
    }

    public void recibeEstado(string e,int turnos)
    {
        bool flag = false;
        for (int i = 0; i < estados.Count; i++)
        {
            if (estados[i] == e)
            {
                cooldowns[i] = turnos;
                muestraEstado(estados[i], cooldowns[i], 1, i);
                i = 10000;
                flag = true;
                
            }
        }
        if (!flag)
        {
            switch (e)
            {
                case "defensa1":
                    cambiaDefensa((int)Math.Round(idef * 0.3, 0));
                    break;
                case "defensa2":
                    cambiaDefensa((int)Math.Round(idef * 0.5, 0));
                    break;
                case "ataque1":
                    cambiaAtaque((int)Math.Round(iad * 0.2, 0));
                    break;
                default:break;
            }

            estados.Add(e);
            cooldowns.Add(turnos);
            muestraEstado(e, turnos, 0, -1);
        }
    }
    
    public void muestraEstado(string e, int turnos, int action, int i)
    {
        if (action == 0)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            textestadoobj.Add(Instantiate(textestado, pos, Quaternion.identity, transform));
            textestadoobj[textestadoobj.Count-1].GetComponent<TextMesh>().text = e + " - " + turnos;
        }
        else if (action == 1)
        {
            textestadoobj[i].GetComponent<TextMesh>().text = e + " - " + turnos;
        }
        else if(action==2)
        {
            Destroy(textestadoobj[i]);
            textestadoobj.RemoveAt(i);
        }
    }

    public void restaCooldowns()
    {
        if (estados.Contains("veneno"))
        {
            cambiaHp((int) Math.Round(mhp * 0.05), 't');
        }
        for (int i =0;i< cooldowns.Count; i++)
        {
            cooldowns[i]= cooldowns[i]-1;
            if (cooldowns[i] != 0)
            {
                muestraEstado(estados[i], cooldowns[i], 1, i);
            }
            else if (cooldowns[i] == 0)
            {
                muestraEstado(estados[i], cooldowns[i], 2, i);
                cooldowns.RemoveAt(i);
                eliminaEstado(estados[i]);
            }
        }


        
    }

    public void eliminaEstado(string e)
    {
        switch (e)
        {
            case "defensa1" : cambiaDefensa((int)Math.Round(-(idef * 0.3), 0));
                break;
            case "defensa2": cambiaDefensa((int)Math.Round(-(idef * 0.5), 0));
                break;
            case "ataque1":
                cambiaAtaque((int)Math.Round(-(iad * 0.2), 0));
                break;
            default: break;
        }
        estados.Remove(e);
    }

    public void cambiaDefensa(int c)
    {
        def = def + c;
    }
    public void cambiaAtaque(int c)
    {
        ad = ad + c;
    }

    public void muerto()
    {
        barH.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        dead = true;
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
        return mhp;
    }
    public bool getDead()
    {
        return dead;
    }
    public int getDef()
    {
        return def;
    }
    public int getMr()
    {
        return mr;
    }
    

}
