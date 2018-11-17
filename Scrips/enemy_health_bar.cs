using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_health_bar : MonoBehaviour
{

    public enemy_health enemy;
    public Text hp;
    public Slider bar;
    // Use this for initialization
    void Start()
    {
        hp.text = "HP: " + enemy.getHp();
        bar.maxValue = enemy.getMaxHp();
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = "HP: " + enemy.getHp();
        bar.value = enemy.getHp();
    }
}
