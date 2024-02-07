using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private int currentScore;
    void Start()
    {
        currentScore = 0;
        scoreText.text = currentScore.ToString();
    }
    public void AddScore(int score)
    {
        currentScore += score;
        scoreText.text = currentScore.ToString();
    }
}
