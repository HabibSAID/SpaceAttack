using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;  // Use the Text component instead of TextMeshProUGUI
    private int score = 0;
    private int bestScore = 0;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BEST_SCORE", 0);
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();

        // Check if the current score is greater than the best score
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BEST_SCORE", bestScore);
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();  // Convert the score to a string before assigning to Text
    }
}
