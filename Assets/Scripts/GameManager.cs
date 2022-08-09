using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score, currentWave, enemyCounted, highScore;
    public static float health;
    public float waitTime, defWaitTime, enemySpd;
    public GameObject _gameoverPanel, _wavePanel;

    public Image _healthBar;

    public Text _scoreText, _waveText, _highscoreText;

    public static bool isWait, isFull;


    public static float enemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        score = 0;
        health = 100;
        currentWave = 1;
        defWaitTime = waitTime;
        isWait = true;
        isFull = true;
    }

    // Update is called once per frame
    void Update()
    {
        enemySpeed = enemySpd;
        _healthBar.fillAmount = health / 100;
        _scoreText.text = "Score : " + score;
        _waveText.text = "Wave " + currentWave + "!";
        _highscoreText.text = "Highscore : " + highScore;


        //DIE
        if(health <= 0)
        {
            Time.timeScale = 0;
            if(score > highScore)
            {
                highScore = score;
            }
            _wavePanel.SetActive(false);
            _gameoverPanel.SetActive(true);
            Debug.Log("lose");
        }

        if (isWait && isFull)
        {

            _wavePanel.SetActive(true);
            if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;

                return;
            }

            //do something
            _wavePanel.SetActive(false);
            //start

            waitTime = defWaitTime;
            currentWave += 1;
            enemyCounted = 0;
            enemySpd += 1;
            SpawnerScipt.jumlahSpawn = 0;
            isFull = false;
            isWait = false;
            
        }

        

    }

    public void goToScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
