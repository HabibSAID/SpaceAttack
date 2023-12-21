using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToGO : MonoBehaviour
{
    public float gameOverDelay = 1.5f;
    public string gameOverSceneName = "GAMEOVER";

    private bool playerDestroyed = false;

    private void Update()
    {
        // Check if there are any active GameObjects with the "Player" tag
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 0 && !playerDestroyed)
        {
            // Set playerDestroyed to true to prevent further detection
            playerDestroyed = true;

            // Switch to game over scene after a delay
            Invoke("LoadGameOverScene", gameOverDelay);
        }
    }

    private void LoadGameOverScene()
    {
        // Save the player's score to PlayerPrefs
        PlayerPrefs.SetInt("SCORE", FindObjectOfType<ScoreManager>().GetScore());
        PlayerPrefs.Save();

        // Load the "Game Over" scene
        SceneManager.LoadScene(gameOverSceneName);
    }
}
