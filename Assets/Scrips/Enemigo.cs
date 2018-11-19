<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System;







public class Enemigo : MonoBehaviour
{

    public float vidabase = 100;
    private float vidaactual;
    public float defensabase = 20;
    private float defensactual;

    public float danobase = 15;
    private float danoactual;
    

    // Use this for initialization
    void Start()
    {
        danoactual = danobase;

        vidaactual = vidabase;
        defensactual = defensabase;


    }

    // Update is called once per frame
    void Update() { }
    public void potenciaataque(float pot)
    {
        danoactual = danoactual + pot;
    }

    public float ataquebasico()
    {
        
        float dano = 0;
        
        
            dano = (danoactual);

        
        return dano;



    }
    public float recibirdano(float dan)
    {
     

        vidaactual = vidaactual - ((1/3)*dan);
        return vidaactual;
    }

    public float recibirCuracion(float c)
    {
        float devolver = 0;
        vidaactual = vidaactual + c;
        if (vidaactual >=vidabase)
        {
            vidaactual = vidabase;
        }
        devolver = vidaactual;
        return devolver;

    }

    public float getVida()
    {
        return vidaactual;
    }
  

    public float aumentaDefensa(float def)
    {
       
        defensactual = defensactual + def;
        return defensactual;
    }
    public float getDefensa()
    {
        return defensactual;
    }
   


}
=======
﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System;







public class Enemigo : MonoBehaviour
{

    public float vidabase = 100;
    private float vidaactual;
    public float defensabase = 20;
    private float defensactual;

    public float danobase = 15;
    private float danoactual;
    

    // Use this for initialization
    void Start()
    {
        danoactual = danobase;

        vidaactual = vidabase;
        defensactual = defensabase;


    }

    // Update is called once per frame
    void Update() { }
    public void potenciaataque(float pot)
    {
        danoactual = danoactual + pot;
    }

    public float ataquebasico()
    {
        
        float dano = 0;
        
        
            dano = (danoactual);

        
        return dano;



    }
    public float recibirdano(float dan)
    {
     

        vidaactual = vidaactual - ((1/3)*dan);
        return vidaactual;
    }

    public float recibirCuracion(float c)
    {
        float devolver = 0;
        vidaactual = vidaactual + c;
        if (vidaactual >=vidabase)
        {
            vidaactual = vidabase;
        }
        devolver = vidaactual;
        return devolver;

    }

    public float getVida()
    {
        return vidaactual;
    }
  

    public float aumentaDefensa(float def)
    {
       
        defensactual = defensactual + def;
        return defensactual;
    }
    public float getDefensa()
    {
        return defensactual;
    }
   


}
>>>>>>> 1073194c9fe8fab16fa451bed0c4c3058c81ada4
