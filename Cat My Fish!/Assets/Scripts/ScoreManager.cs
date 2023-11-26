using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] int cantidad = 1;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public GameObject menuCompletado;
    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("higscore", 0);
        scoreText.text = score.ToString() + " /12 Peces Capturados";
        highscoreText.text = "Puntaje Alcanzado: " + highscore.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " /12 Peces Capturados";
        if(highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        if (score == cantidad)
        {
            menuCompletado.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
