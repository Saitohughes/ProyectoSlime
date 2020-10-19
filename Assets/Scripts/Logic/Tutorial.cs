using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;
    [SerializeField] private bool hiden;
    // Start is called before the first frame update
    void Start()
    {
        if (!hiden)
        {
            tutorial.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Hide()
    {
        hiden = false;
        tutorial.SetActive(false);
        Time.timeScale = 1f;
    }
}
