using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : BaseCharacter, IScoreable
{
    private int score, highscore;
    public Text _scoreText, _highscoreText;

    void Update()
    {
        _scoreText.text = "Score : " + score;
        _highscoreText.text = "Highscore : " + highscore;
    }

    public void AddScore()
    {

        Debug.Log("score = " + score.ToString());
        score++;
    }

    public void checkHighScore()
    {
        if(score > highscore)
        {
            setHighScore();
        }
    }

    public void setHighScore()
    {
        highscore = score;
        score = 0;
    }
}
