﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

    public GameObject button;
    public GameObject screen;
    private bool isOpen;
	// Use this for initialization
	void Start () {
        isOpen = false;
        button.SetActive(false);
        screen.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape") && !isOpen)
        {
            // Debug.Log("activo");
            screen.SetActive(true);
            button.SetActive(true);
            isOpen = true;
        }
        else if (Input.GetKeyDown("escape") && isOpen)
        {
            // Debug.Log("inactivo");
            screen.SetActive(false);
            button.SetActive(false);
            isOpen = false;
        }
    }

    public void LoadMenu()
    {
        //Debug.Log("wow");
        SceneManager.LoadScene("_MainMenu");
    }
}
