using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScipt : MonoBehaviour
{
    public Transform spawn1, spawn2, spawn3, spawn4, spawn5;
    public float jeda, defJeda;
    public static float  jumlahSpawnDef, jumlahSpawn;

    public GameObject enemy, human;
    public int randomize, randomize2, jumlahSpawnEnemy;

    [SerializeField] private bool canSpawn, isWait;
    // Start is called before the first frame update
    void Start()
    {
        defJeda = jeda;
        canSpawn = true;
        jumlahSpawn = 0;
        jumlahSpawnDef = jumlahSpawnEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        isWait = GameManager.isWait;
        
        if(GameManager.enemyCounted < jumlahSpawnDef)
        {
            canSpawn = true;
        }
       

        randomize2 = Random.Range(1, 6);
        randomize = Random.Range(1, 6);

        if(jumlahSpawn == jumlahSpawnDef)
        {
            canSpawn = false;
        }


        if (!isWait)
        {




            if (GameManager.enemyCounted >= jumlahSpawnDef)
            {
                GameManager.isWait = true;
                GameManager.isFull = true;
                canSpawn = false;
                Debug.Log("Meneng tol");
                return;
            }



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


        if (randomize == 1) 
        {
            if (randomize2 > 2)
            {
                Instantiate(enemy, spawn1.position, Quaternion.identity);
            }
            else
            {
                Instantiate(human, spawn1.position, Quaternion.identity);
            }

        }

        if (randomize == 2)
        {
            if (randomize2 > 2)
            {
                Instantiate(enemy, spawn2.position, Quaternion.identity);
            }
            else
            {
                Instantiate(human, spawn2.position, Quaternion.identity);
            }

        }

        if (randomize == 3)
        {
            if (randomize2 > 2)
            {
                Instantiate(enemy, spawn3.position, Quaternion.identity);
            }
            else
            {
                Instantiate(human, spawn3.position, Quaternion.identity);
            }

        }

        if (randomize == 4)
        {
            if (randomize2 > 2)
            {
                Instantiate(enemy, spawn4.position, Quaternion.identity);
            }
            else
            {
                Instantiate(human, spawn4.position, Quaternion.identity);
            }

        }

        if (randomize == 5)
        {
            if (randomize2 > 2)
            {
                Instantiate(enemy, spawn5.position, Quaternion.identity);
            }
            else
            {
                Instantiate(human, spawn5.position, Quaternion.identity);
            }

        }
        jumlahSpawn += 1;
    }
}
