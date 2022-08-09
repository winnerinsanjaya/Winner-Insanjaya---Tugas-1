using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyScript : MonoBehaviour
{
    public float speed, damage;
    public bool isHuman;
    // Start is called before the first frame update
    void Start()
    {
        speed = GameManager.enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
    }

    private void OnMouseDown()
    {
        if (isHuman)
        {
            GameManager.health = 0;
            Debug.Log("lose");
        }

        else
        {
            GameManager.score += 1;
            Debug.Log("win");
        }
        GameManager.enemyCounted += 1;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "pembatas")
        {
            if (isHuman)
            {
                GameManager.score += 1;
            }

            if (!isHuman)
            {
                GameManager.health -= damage;
            }

            GameManager.enemyCounted += 1;
            Destroy(gameObject);
            Debug.Log("Nyawa Berkurang");
        }
    }
}
