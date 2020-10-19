using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private int currentLevels, unlockLevels;
    [SerializeField] private GameObject complete1, complete2, complete3;
    
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

        if (unlockLevels >= 8)
            complete1.SetActive(true);

        if (unlockLevels >= 14)
            complete2.SetActive(true);

        if (unlockLevels >= 19)
            complete3.SetActive(true);

    }
    public void ChangeLevel(int level = 0)
    {
        SceneManager.LoadScene(level);
    }

}
