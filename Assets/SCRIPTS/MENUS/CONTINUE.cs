using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CONTINUE : MonoBehaviour
{
    public string sceneToLoad = "MAIN MENU"; // Set the scene name in the Unity Editor
    public Button yourButton; // Reference to your UI button

    void Start()
    {
        // Attach the ChangeScene method to the button's click event
        yourButton.onClick.AddListener(ChangeScene);
    }

    // This method will be called when the button is clicked
    void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
