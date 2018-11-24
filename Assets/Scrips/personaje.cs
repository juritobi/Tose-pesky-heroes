using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class personaje : MonoBehaviour {
	public Slider barH;
	public int mhp;
	public int hp;
	public int ad;
	public int ap;
    public int def;
    public int mr;
    protected List<string> estados;


	// Use this for initialization
	void Start () {
        hp = mhp;
		estados=new List<string>();
	}

	// Update is called once per frame
	void Update () {
		barH.value=hp;
	}

	public void cambiaHp(int c){
		if (c>0) {
			hp=hp-c;
			if(hp<0){
				hp = 0;
			}
		}
		else{
			hp=hp-c;
			if(hp>mhp){
				hp=mhp;
			}
		}
	}
    public void recibeEstado(string e)
    {

    }
    public void eliminaEstado(string e)
    {

    }
	public void cambiaDefensa(int c)
	{
			def = def + c;
	}

}
