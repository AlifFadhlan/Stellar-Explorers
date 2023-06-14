using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int score = 0;
    private int highscore = 0;
    private float timer = 0f;
    public float interval = 1f;
    private bool isScoreActive = false;

    public void StartScore()
    {
        isScoreActive = true;
        InvokeRepeating("IncreaseScore", interval, interval);
    }

    public void StopScore()
    {
        isScoreActive = false;
        CancelInvoke("IncreaseScore");
    }

    void Update()
    {
        if (isScoreActive)
        {
            timer += Time.deltaTime;
        }
    }

    void IncreaseScore()
    {
        if (timer >= interval)
        {
            score += 10;
            scoreText.text = score.ToString();
            timer = 0f;
        }
    }

    public void UpdateHighscore()
    {
        if (score > highscore)
        {
            highscore = score;
            highScoreText.text = highscore.ToString();
        }
    }
}
