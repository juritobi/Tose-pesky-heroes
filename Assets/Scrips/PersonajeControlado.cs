<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;








public class PersonajeControlado : MonoBehaviour {

    public const float vidabase = 100;
    private float vidaactual;
    public const float defensabase = 40;
    private float defensactual;
    private float posibilidades = 0;
    public const  float danobase=30;
    private float danoactual;
    private float probcriticobase = 0.2f;
    private float probcriticoact;
    public const float manabase = 0;
    private float manactual;

    // Use this for initialization
    void Start () {
        danoactual = danobase;
        probcriticoact = probcriticobase;
        vidaactual = vidabase;
        defensactual = defensabase;
        manactual = manabase;
     
		
	}

    // Update is called once per frame
    void Update() { }

    public float potenciaataque(float pot)
        {
            danoactual = danoactual + pot;
        return danoactual;
        }

    public float aumentamana(float man)
    {
        manactual = manactual + man;
        return manactual;
    }
    public float getMana()
    {
        return manactual;
    }

    public float ataquebasico()
        {
           
            float dano = 0;
            bool critsiono = false;
            critsiono = esCrit();
            if (critsiono == true)
            {
            dano = ((danoactual * 0.3f) + danoactual);
       

                
                
            }
            else
            {
            dano = (danoactual);

           
            }
        return dano;



        }
    public float recibirdano(float dan)
    { 

        vidaactual = vidaactual -((1/3)*dan) ;
        return vidaactual;
        
    }
    public float aumentaprobcrit(float prob)
        {
        float devolver = 0;
            devolver = probcriticoact + prob;
        return devolver;
        }
   

    public bool esCrit()
    {

        float crit = Random.Range(0.0f, 2.0f);
        bool respuesta = false;
      
       
        if (posibilidades+probcriticoact>=crit)
        {
            respuesta = true;
            posibilidades = 0;
        }
        else
        {
            respuesta = false;
            posibilidades = posibilidades + 0.1f;

        }
        return respuesta;
    }

    public float recibirCuracion(float c)
    {
        float devolver = 0;
        vidaactual = vidaactual + c;
        if (vidaactual >= vidabase)
        {
            vidaactual =vidabase;
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








public class PersonajeControlado : MonoBehaviour {

    public const float vidabase = 100;
    private float vidaactual;
    public const float defensabase = 40;
    private float defensactual;
    private float posibilidades = 0;
    public const  float danobase=30;
    private float danoactual;
    private float probcriticobase = 0.2f;
    private float probcriticoact;
    public const float manabase = 0;
    private float manactual;

    // Use this for initialization
    void Start () {
        danoactual = danobase;
        probcriticoact = probcriticobase;
        vidaactual = vidabase;
        defensactual = defensabase;
        manactual = manabase;
     
		
	}

    // Update is called once per frame
    void Update() { }
    public float potenciaataque(float pot)
        {
            danoactual = danoactual + pot;
        return danoactual;
        }

    public float aumentamana(float man)
    {
        manactual = manactual + man;
        return manactual;
    }
    public float getMana()
    {
        return manactual;
    }

    public float ataquebasico()
        {
           
            float dano = 0;
            bool critsiono = false;
            critsiono = esCrit();
            if (critsiono == true)
            {
            dano = ((danoactual * 0.3f) + danoactual);
       

                
                
            }
            else
            {
            dano = (danoactual);

           
            }
        return dano;



        }
    public float recibirdano(float dan)
    { 

        vidaactual = vidaactual -((1/3)*dan) ;
        return vidaactual;
        
    }
    public float aumentaprobcrit(float prob)
        {
        float devolver = 0;
            devolver = probcriticoact + prob;
        return devolver;
        }
   

    public bool esCrit()
    {

        float crit = Random.Range(0.0f, 2.0f);
        bool respuesta = false;
      
       
        if (posibilidades+probcriticoact>=crit)
        {
            respuesta = true;
            posibilidades = 0;
        }
        else
        {
            respuesta = false;
            posibilidades = posibilidades + 0.1f;

        }
        return respuesta;
    }

    public float recibirCuracion(float c)
    {
        float devolver = 0;
        vidaactual = vidaactual + c;
        if (vidaactual >= vidabase)
        {
            vidaactual =vidabase;
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
