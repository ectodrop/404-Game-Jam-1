using UnityEngine;
using UnityEngine.UI; // Required for the Button component
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public string sceneToLoad;

    void Start()
    {
        Button btn = this.gameObject.GetComponent<Button>(); // Get the Button component
        if (btn != null)
        {
            btn.onClick.AddListener(TaskOnClick); // Add the listener to the Button component
        }
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");   
        SceneManager.LoadScene(sceneToLoad); // Load the specified scene
    }
}