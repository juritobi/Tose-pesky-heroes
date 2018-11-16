using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterGameScript : MonoBehaviour {

    public void next()
    {
        SceneManager.LoadScene("_MainMenu");
    }

}
