using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;

    private int currentWave, enemyCount;

    private float health, defWaitTime;

    [SerializeField] private float waitTime;

    [SerializeField] private int enemyMuch;

    private bool isWait, isFull;

    public GameObject _gameoverPanel, _wavePanel;

    public Image _healthBar;

    public Text _waveText;

    void Start()
    {
        Time.timeScale = 1;

        health = 100;

        currentWave = 1;

        defWaitTime = waitTime;

        isWait = true;

        isFull = true;
    }

    void Update()
    {

        _healthBar.fillAmount = health / 100;

        _waveText.text = "Wave " + currentWave + "!";


        if(enemyCount == enemyMuch)
        {
            isWait = true;
            enemyCount = 0;
        }


        if (isWait)
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

            SpawnerScipt scoreManager = gameObject.GetComponent<SpawnerScipt>();
            scoreManager.disIsWait();

            isWait = false;
            
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

        Debug.Log("gameover");
    }

    public void AddEnemyCount()
    {
        enemyCount++;
    }

}
