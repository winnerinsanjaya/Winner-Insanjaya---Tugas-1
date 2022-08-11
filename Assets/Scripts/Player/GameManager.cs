using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;

    private int  enemyCount, enemyLeft;

    public float currentWave;

    private float defWaitTime;

    [SerializeField] private float waitTime;

    [SerializeField] private int enemyMuch;

    private bool isWait, isFull;

    public GameObject _gameoverPanel, _wavePanel, _inGamePanel;

    public Text _waveText;

    void Start()
    {
        Time.timeScale = 1;

        currentWave = 1;

        defWaitTime = waitTime;

        isWait = true;

        isFull = true;

        enemyLeft = enemyMuch;
    }

    void Update()
    {

        _waveText.text = "Wave " + currentWave + "!";


        if(enemyCount == enemyMuch)
        {
            isWait = true;
            disableSpawn();
            enemyCount = 0;
        }

        if(enemyLeft == 0)
        {
            isFull = true;
            disableSpawn();
            enemyLeft = enemyMuch;
        }


        if (isWait && isFull)
        {

            _wavePanel.SetActive(true);

            if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;
                return;
            }

            _wavePanel.SetActive(false);

            waitTime = defWaitTime;

            currentWave += 1;

            actSpawn();

            isWait = false;

            isFull = false;
            
        }
    }

    public void goToScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void GameOver()
    {
        Time.timeScale = 0;

        ScoreManager scoreManager = gameObject.GetComponent<ScoreManager>();
        scoreManager.checkHighScore();

        _wavePanel.SetActive(false);

        _gameoverPanel.SetActive(true);

        _inGamePanel.SetActive(false);
        Debug.Log("gameover");
    }

    public void AddEnemyCount()
    {
        enemyCount++;
    }

    public void minEnemyLeft()
    {
        enemyLeft--;
    }

    public void disableSpawn()
    {
        SpawnerScipt scoreManager = gameObject.GetComponent<SpawnerScipt>();
        scoreManager.actIsWait();
    }

    public void actSpawn()
    {
        SpawnerScipt scoreManager = gameObject.GetComponent<SpawnerScipt>();
        scoreManager.disIsWait();
    }
}
