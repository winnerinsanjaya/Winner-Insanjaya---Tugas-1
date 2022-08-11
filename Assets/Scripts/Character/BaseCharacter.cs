using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseCharacter : MonoBehaviour, IClickable
{
    [SerializeField]
    private float speed, damage;

    private GameObject enemyDeathEffect, manager;
    public void setEffect(GameObject efx)
    {
        enemyDeathEffect = efx;

    }

    public void Move()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
        Debug.Log(speed);
    }


    public void checkBorder()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.width || screenPosition.y < 0)
        {
            if(gameObject.tag == "human")
            {
                GameObject gmobject = GameObject.Find("MANAGER");
                AddScore(gmobject);
            }

            minEnemyLeft();
            DamagePlayer(damage);
            Destroy(gameObject);
        }
    }

    public void Kill(GameObject gmobject)
    {
        Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);

        
        GameObject foo = transform.parent.gameObject;
        transform.parent = null;

        AddScore(gmobject);

        Destroy(foo);
        Destroy(gameObject);

    }

    public void Lose(GameObject gmobject)
    {
        gameOver(gmobject);
    }

    public void TakeDamage(GameObject gmobject)
    {

        minEnemyLeft();

        if (gameObject.tag == "enemy")
        {
            Kill(gmobject);
        }

        if (gameObject.tag == "human")
        {
            Lose(gmobject);
        }
    }

    public void minEnemyLeft()
    {
        manager = GameObject.Find("MANAGER");
        GameManager gamemanager = manager.GetComponent<GameManager>();
        gamemanager.minEnemyLeft();
    }

    public void gameOver(GameObject gmobject)
    {
        GameManager gamemanager = gmobject.GetComponent<GameManager>();
        gamemanager.GameOver();
    }

    public void AddScore(GameObject gmobject)
    {
        ScoreManager scoreManager = gmobject.GetComponent<ScoreManager>();
        scoreManager.AddScore();
    }

    public void DamagePlayer(float dmg)
    {
        manager = GameObject.Find("MANAGER");
        HealthManager healthmanager = manager.GetComponent<HealthManager>();
        healthmanager.Damage(dmg);
    }


    public void SetSpeed()
    {
        manager = GameObject.Find("MANAGER");
        GameManager gamemanager = manager.GetComponent<GameManager>();
        speed += ((gamemanager.currentWave - 2) / 2);

    }

}
