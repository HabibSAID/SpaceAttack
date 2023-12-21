using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;  // Public variable for the scene name

    // Public method to be called when the button is pressed
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
