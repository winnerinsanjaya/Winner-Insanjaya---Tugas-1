using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public Image _healthBar;

    private float health;
    void Start()
    {
        health = 100;
    }

    void Update()
    {
        _healthBar.fillAmount = health / 100;
        checkHealth();
    }

    public void Damage(float dmg)
    {
        health -= dmg;
    }

    public void checkHealth()
    {
        if(health  <= 0)
        {
            GameManager gamemanager = gameObject.GetComponent<GameManager>();
            gamemanager.GameOver();
        }
    }
}
