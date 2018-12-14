using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public static int almas;

    public AudioSource BadAssMusic;

    public void StartGame ()
    {
        SceneManager.LoadScene("prueba");
    }

    public void QuitGame()
    {
        Application.Quit();

    }
    public void CambiaVolumen(Slider vol)
    {
        BadAssMusic.volume = vol.value;
        Debug.Log(vol.value);
    }



}
