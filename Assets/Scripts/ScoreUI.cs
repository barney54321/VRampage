using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText = null;

    private int score = 0;

    private void OnEnable()
    {
        EnemyShooter.onEnemyKilled += UpdateText;
    }

    private void OnDisable()
    {
        EnemyShooter.onEnemyKilled -= UpdateText;
    }

    private void UpdateText()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }
}
