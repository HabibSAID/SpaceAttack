using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Button loadSceneButton;
    public Button quitGameButton;

    
    public void Start()
    {
        loadSceneButton.onClick.AddListener(LoadScene);
        quitGameButton.onClick.AddListener(QuitGame);
        
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("GAME");
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}
