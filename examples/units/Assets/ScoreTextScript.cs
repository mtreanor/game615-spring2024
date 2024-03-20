using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextScript : MonoBehaviour
{
    public TMP_Text scoreText;

    private void OnEnable()
    {
        GameManager.ScoreUpdated += UpdateScoreText;
    }

    private void OnDisable()
    {
        GameManager.ScoreUpdated -= UpdateScoreText;
    }

    void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}
