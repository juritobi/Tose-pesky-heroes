using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class jugador : personaje
{
    private int cosa;


    // Use this for initialization
    void Start()
    {
        mhp = 2000;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void hazcosas()
    {
        Debug.Log("yay");
    }

}