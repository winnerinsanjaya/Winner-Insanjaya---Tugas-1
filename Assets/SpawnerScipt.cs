using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScipt : MonoBehaviour
{
    public Transform spawn1, spawn2, spawn3, spawn4, spawn5;
    public float jeda, defJeda;
    public int humanCountdown, humanCountdownDef;

    public GameObject enemy, human;
    public int randomize, randomize2;

    // Start is called before the first frame update
    void Start()
    {
        defJeda = jeda;
        humanCountdownDef = humanCountdown;
    }

    // Update is called once per frame
    void Update()
    {
        randomize2 = Random.Range(1, 5);
        randomize = Random.Range(1, 6); 
        if (jeda > 0)
        {
            jeda -= Time.deltaTime; 

            return; 
        }


         Spawn();



        jeda = defJeda;
    }

    public void Spawn() 
    {


        if (randomize == 1) 
        {
            if (randomize2 > 2)
            {
                Instantiate(enemy, spawn1.position, Quaternion.identity);
                humanCountdown -= 1;
            }
            else
            {
                Instantiate(human, spawn1.position, Quaternion.identity); 
                humanCountdown = humanCountdownDef; 
            }

        }

        if (randomize == 2)
        {
            if (randomize2 > 2)
            {
                Instantiate(enemy, spawn2.position, Quaternion.identity);
                humanCountdown -= 1; 
            }
            else
            {
                Instantiate(human, spawn2.position, Quaternion.identity);
                humanCountdown = humanCountdownDef; 
            }

        }

        if (randomize == 3)
        {
            if (randomize2 > 2)
            {
                Instantiate(enemy, spawn3.position, Quaternion.identity);
                humanCountdown -= 1;
            }
            else
            {
                Instantiate(human, spawn3.position, Quaternion.identity);
                humanCountdown = humanCountdownDef;
            }

        }

        if (randomize == 4)
        {
            if (randomize2 > 2)
            {
                Instantiate(enemy, spawn4.position, Quaternion.identity);
                humanCountdown -= 1;
            }
            else
            {
                Instantiate(human, spawn4.position, Quaternion.identity);
                humanCountdown = humanCountdownDef;
            }

        }

        if (randomize == 5)
        {
            if (randomize2 > 2)
            {
                Instantiate(enemy, spawn5.position, Quaternion.identity);
                humanCountdown -= 1;
            }
            else
            {
                Instantiate(human, spawn5.position, Quaternion.identity);
                humanCountdown = humanCountdownDef;
            }

        }
    }
}
