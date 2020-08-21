using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int thisScene;
    private void Start()
    {
        thisScene = SceneManager.GetActiveScene().buildIndex;
    }
    // Start is called before the first frame update
    public void Restart()
    {
        int thisScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(thisScene);
    }

    public void NextScene( )
    {
        SceneManager.LoadScene(thisScene + 1 );
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("SelectorScreen");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
