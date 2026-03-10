using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public string sceneToLoad;

    public void SceneToLoad()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    
}


