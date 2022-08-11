using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ZombieTap.character
{
    public class SpawnerScipt : MonoBehaviour
    {
        [Header("Pool Section")]
        [SerializeField] PoolUnit<HumanScript> humanPool;
        [SerializeField] PoolUnit<EnemyScript> zombiePool;

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

            core.GameManager gamemanager = gameObject.GetComponent<core.GameManager>();
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
            core.GameManager gamemanager = gameObject.GetComponent<core.GameManager>();
            gamemanager.AddEnemyCount();
            BaseCharacter createdUnit;
            if (randomize2 > 2)
            {
                createdUnit = zombiePool.GetObject();
                createdUnit.transform.GetChild(0).gameObject.SetActive(true);
                //Instantiate(enemy, spawnPos[randomize].position, Quaternion.identity);
            }
            else
            {
                createdUnit = humanPool.GetObject();
                //Instantiate(human, spawnPos[randomize].position, Quaternion.identity);
            }





            createdUnit.gameObject.SetActive(true);
            createdUnit.transform.position = spawnPos[Random.Range(0, spawnPos.Length)].position;
            /*
            bool asZombie = Random.Range(1, 101) > 10;
            BaseUnit createdUnit = asZombie ? zombiePool.GetObject() : humanPool.GetObject();


            createdUnit.gameObject.SetActive(true);
            createdUnit.transform.position = spawnPos[Random.Range(0, spawnPos.Length)].position;
            createdUnit.transform.SetParent(asZombie ? zombiePos : humanPos);
            */
        }

        public void disIsWait()
        {
            isWait = false;
        }

        public void actIsWait()
        {
            isWait = true;
        }



        /////////
        [System.Serializable]
        public class PoolUnit<T> where T : BaseCharacter
        {
            [SerializeField] List<UnitSpawnData> variationUnits;
            public T GetObject()
            {
                T createdUnit;

                var variationTarget = variationUnits[Random.Range(0, variationUnits.Count)];
                if (variationTarget.pool.Count <= 0)
                {
                    createdUnit = Instantiate(variationTarget.unitBaseObject);
                    createdUnit.OnUnitDie += () => { StoreUnit(createdUnit); };
                }
                else
                {
                    createdUnit = variationTarget.pool.Dequeue();
                }

                return createdUnit;
            }

            public void StoreUnit(T unit)
            {
                for (int i = 0; i < variationUnits.Count; i++)
                {
                    if (variationUnits[i].unitBaseObject.GetType() == unit.GetType())
                    {
                        variationUnits[i].pool.Enqueue(unit);
                        return;
                    }
                }
            }

            [System.Serializable]
            class UnitSpawnData
            {
                public T unitBaseObject;
                public Queue<T> pool = new Queue<T>();
            }
        }
    }
}
