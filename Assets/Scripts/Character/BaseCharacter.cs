using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieTap.character
{
    public abstract class BaseCharacter : MonoBehaviour, IClickable
    {
        public System.Action OnUnitDie;

        private bool isCountable;

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
        }


        public void checkBorder()
        {
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            if (screenPosition.y > Screen.width || screenPosition.y < 0)
            {
                if (gameObject.tag == "human")
                {
                    GameObject gmobject = GameObject.Find("MANAGER");
                    AddScore(gmobject);
                }

                DamagePlayer(damage);
                minEnemyLeft();
                OnUnitDie?.Invoke();
                gameObject.SetActive(false);
            }
        }

        public void Kill(GameObject gmobject)
        {
            Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);



            AddScore(gmobject);

            OnUnitDie?.Invoke();

            Destroy(transform.parent.gameObject);
            Destroy(gameObject);

        }

        public void Lose(GameObject gmobject)
        {
            gameOver(gmobject);
        }

        public void TakeDamage(GameObject gmobject)
        {

            //minEnemyLeft();

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
            core.GameManager gamemanager = manager.GetComponent<core.GameManager>();
            gamemanager.minEnemyLeft();
        }

        public void plusEnemyLeft()
        {
            manager = GameObject.Find("MANAGER");
            core.GameManager gamemanager = manager.GetComponent<core.GameManager>();
            gamemanager.plusEnemyLeft();
        }

        public void gameOver(GameObject gmobject)
        {
            core.GameManager gamemanager = gmobject.GetComponent<core.GameManager>();
            gamemanager.GameOver();
        }

        public void AddScore(GameObject gmobject)
        {
            core.ScoreManager scoreManager = gmobject.GetComponent<core.ScoreManager>();
            scoreManager.AddScore();
        }

        public void DamagePlayer(float dmg)
        {
            manager = GameObject.Find("MANAGER");
            core.HealthManager healthmanager = manager.GetComponent<core.HealthManager>();
            healthmanager.Damage(dmg);
        }


        public void SetSpeed()
        {
            manager = GameObject.Find("MANAGER");
            core.GameManager gamemanager = manager.GetComponent<core.GameManager>();
            speed += ((gamemanager.currentWave - 2) / 2);

        }

    }
}