using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] int nextScene, currentScene;
    // Start is called before the first frame update
    public void Restart()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
