﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCount : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int mycount;

    public static LevelCount instance;

    public static LevelCount Instance { get => instance; }
    // Update is called once per frame
    private void Awake()
    {
        
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        //PlayerPrefs.DeleteAll();
        DontDestroyOnLoad(gameObject);
#if UNITY_EDITOR
        PlayerPrefs.SetInt("turorialProgress", 0);
        PlayerPrefs.SetInt("turorialProgress", mycount);
#endif

        mycount = PlayerPrefs.GetInt("turorialProgress", mycount); 
    }

    public int Mycount { get => mycount; }
    public void UpdateCount()
    {
        mycount++;
        PlayerPrefs.SetInt("turorialProgress", mycount);
    }

}
