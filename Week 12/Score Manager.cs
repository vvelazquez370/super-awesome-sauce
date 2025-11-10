using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }
    public void UpdateScoreText()
    {
        string v = "Score: " + score.ToString();
        scoreText.text = v;
    }
}