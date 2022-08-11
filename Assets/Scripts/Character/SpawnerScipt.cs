using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScipt : MonoBehaviour
{

    public Transform[] spawnPos;
    
    [SerializeField]
    private float jeda;
    private float defJeda;

    private int randomize, randomize2, jumlahSpawnEnemy;

    public GameObject enemy, human;

    [SerializeField] 
    private bool canSpawn, isWait;

    void Start()
    {
        isWait = true;

        defJeda = jeda;

        canSpawn = true;

        GameManager gamemanager = gameObject.GetComponent<GameManager>();
    }

    void Update()
    {
        randomize2 = Random.Range(1, 6);
        randomize = Random.Range(0, spawnPos.Length);
        

        if (!isWait)
        {

            if (jeda > 0)
            {
                jeda -= Time.deltaTime;

                return;
            }

            if (canSpawn)
            {
                
                Spawn();
            }

            jeda = defJeda;
            
        }
    }

    public void Spawn()
    {
        if (randomize2 > 2)
        {
            Instantiate(enemy, spawnPos[randomize].position, Quaternion.identity);
        }
        else
        {
            Instantiate(human, spawnPos[randomize].position, Quaternion.identity);
        }

        GameManager gamemanager = gameObject.GetComponent<GameManager>();
        gamemanager.AddEnemyCount();
    }

    public void disIsWait()
    {
        isWait = false;
    }

    public void actIsWait()
    {
        isWait = true;
    }
}
