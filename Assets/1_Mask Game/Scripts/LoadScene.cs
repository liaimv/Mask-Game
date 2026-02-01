using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    public bool onEnd = false;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(sceneName);

        if (onEnd)
        {
            Data.onStart = true;
            Data.onLevel1 = false;
            Data.onLevel2 = false;
            Data.onLevel3 = false;
        }
        else if (Data.onStart)
        {
            Data.onLevel1 = true;
            Data.onStart = false;
        }
        else if (Data.onLevel1)
        {
            Data.onLevel2 = true;
            Data.onLevel1 = false;
        }
        else if (Data.onLevel2)
        {
            Data.onLevel3 = true;
            Data.onLevel2 = false;
        }
        else if (Data.onLevel3)
        {
            Data.onStart = true;
            Data.onLevel3 = false;
        }
    }
}
