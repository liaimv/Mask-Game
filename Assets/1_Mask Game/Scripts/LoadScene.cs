using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
