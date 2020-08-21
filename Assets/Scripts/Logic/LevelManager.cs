using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] int currentLevels, unlockLevels;
    
     //LevelCount mycounter;
    // Start is called before the first frame update
    void Start()
    {
       
        currentLevels = LevelCount.Instance.Mycount;

        UnlockLevels();
        UpdateButtons();
    }

    public void UnlockLevels()
    {
        if (unlockLevels < currentLevels)
        {
            unlockLevels = currentLevels;
        }
    }
   public void UpdateButtons()
    {
        for (int i = 0; i < unlockLevels + 1 ; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void ChangeLevel(int level = 0)
    {
        SceneManager.LoadScene(level);
    }

}
