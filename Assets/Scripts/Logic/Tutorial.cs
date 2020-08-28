using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject tutorial;
    [SerializeField] bool hiden;
    // Start is called before the first frame update
    void Start()
    {
        if (!hiden)
        {
            tutorial.SetActive(true);
        }
    }

    public void Hide()
    {
        hiden = false;
        tutorial.SetActive(false);
    }
}
