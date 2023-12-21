using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;  // Use the Text component instead of TextMeshProUGUI
    public Text bestScoreText; // Text component for displaying the best score

    void Start()
    {
        // Get the player's score and best score from PlayerPrefs
        int score = PlayerPrefs.GetInt("SCORE", 0);
        int bestScore = PlayerPrefs.GetInt("BEST_SCORE", 0);

        // Update the UI Text elements with the player's score and best score
        scoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
    }
}
