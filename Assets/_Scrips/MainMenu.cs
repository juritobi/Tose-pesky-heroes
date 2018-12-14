using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public static int almas;

    public void StartGame ()
    {
        SceneManager.LoadScene("prueba");
    }

    public void QuitGame()
    {
        Application.Quit();

    }



}
