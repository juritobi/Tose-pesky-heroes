using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class global_attack : MonoBehaviour {

    public enemy_health Enemy;
    public player_health Player;
    private bool pause;

	// Use this for initialization
	void Start () {
        pause = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") && !pause)
        {
            Enemy.takeDamage(20);
        }
        else if (Input.GetKeyDown("down") && !pause)
        {
            Player.TakeDamage(10);
        }
        else if (Input.GetKeyDown("escape"))
        {
            if (pause)
            {
                pause = false;
            }
            else
            {
                pause = true;
            }
        }
    }

  

}
