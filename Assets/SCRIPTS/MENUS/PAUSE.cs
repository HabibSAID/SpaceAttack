using UnityEngine;

public class PAUSE : MonoBehaviour
{
    private bool isPaused = false;

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f; // Pause the game
            isPaused = true;
        }
    }

    public void ResumeGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1f; // Resume the game with the regular time scale
            isPaused = false;
        }
    }
}
