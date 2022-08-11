using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZombieTap.core
{
    public class ScoreManager : character.BaseCharacter, IScoreable
    {
        private int score;
        public Text _scoreText, _highscoreText, _hghscoreText;

        void Update()
        {
            _scoreText.text = "Score : " + score;
            _highscoreText.text = "Highscore : " + PlayerPrefs.GetInt("highscore");
            _hghscoreText.text = "Highscore : " + PlayerPrefs.GetInt("highscore");
        }

        public void AddScore()
        {

            Debug.Log("score = " + score.ToString());
            score++;
        }

        public void checkHighScore()
        {
            if (score > PlayerPrefs.GetInt("highscore"))
            {
                setHighScore();
            }
        }

        public void setHighScore()
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
