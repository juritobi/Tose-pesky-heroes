﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour {

    public GameObject button;
    public GameObject screen;
    public GameObject Overlay;
    public Slider barrita;
    public AudioSource vol;
    private bool isOpen;
	// Use this for initialization
	void Start () {
        isOpen = false;
        screen.SetActive(false);
        button.SetActive(false);
        Overlay.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape") && !isOpen)
        {
            // Debug.Log("activo");
            screen.SetActive(true);
            button.SetActive(true);
            Overlay.SetActive(false);
           
            isOpen = true;
        }
        else if (Input.GetKeyDown("escape") && isOpen)
        {
            // Debug.Log("inactivo");
            screen.SetActive(false);
            button.SetActive(false);
          
            Overlay.SetActive(true);
            isOpen = false;
        }
    }

    

    public void LoadMenu()
    {
        //Debug.Log("wow");
        SceneManager.LoadScene("_MainMenu");
    }
    public void cambiaVolumen(Slider s){
        vol.volume=s.value;
        Debug.Log(s.value);
    }
}
