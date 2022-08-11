using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseCharacter : MonoBehaviour, IClickable
{
    [SerializeField]
    private float speed;

    private GameObject enemyDeathEffect, manager;
    public void setEffect(GameObject efx)
    {
        enemyDeathEffect = efx;

    }
    public void Move()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
    }


    public void checkBorder()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.width || screenPosition.y < 0)

        manager = GameObject.Find("MANAGER");

        GameManager gamemanager = manager.GetComponent<GameManager>();
        gamemanager.AddEnemyCount();



        Destroy(gameObject);
    }

    public void Kill(GameObject gmobject)
    {
        Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);

        
        GameObject foo = transform.parent.gameObject;
        transform.parent = null;

        ScoreManager scoreManager = gmobject.GetComponent<ScoreManager>();
        scoreManager.AddScore();

        Destroy(foo);
        Destroy(gameObject);

    }

    public void Lose(GameObject gmobject)
    {
        GameManager gamemanager = gmobject.GetComponent<GameManager>();
        gamemanager.GameOver();
    }

    public void TakeDamage(GameObject gmobject)
    {
        if(gameObject.tag == "enemy")
        {
            Debug.Log("asu");
            Kill(gmobject);
        }

        if (gameObject.tag == "human")
        {
            Lose(gmobject);
        }
    }
}
