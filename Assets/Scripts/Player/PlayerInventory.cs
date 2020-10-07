﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int myMoney;
    [SerializeField] private int[] inventory;

    public static PlayerInventory instance;

    public int MyMoney { get => myMoney; set => myMoney = value; }
    public int[] Inventory { get => inventory; set => inventory = value; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);

#if UNITY_EDITOR
        PlayerPrefs.SetInt("myMoney", 0);
        PlayerPrefs.SetInt("myMoney", MyMoney);

        PlayerPrefs.SetInt("mtInventory", 0);
        PlayerPrefs.SetInt("mtInventory", inventory[0]);

        PlayerPrefs.SetInt("smInventory", 0);
        PlayerPrefs.SetInt("smInventory", inventory[1]);

        PlayerPrefs.SetInt("gmInventory", 0);
        PlayerPrefs.SetInt("gmInventory", inventory[2]);
#endif

        MyMoney = PlayerPrefs.GetInt("myMoney");
        inventory[0] = PlayerPrefs.GetInt("mtInventory");
        inventory[1] = PlayerPrefs.GetInt("smInventory");
        inventory[2] = PlayerPrefs.GetInt("gmInventory");
    }
    public void Actualice()
    {
        PlayerPrefs.SetInt("myMoney",MyMoney);
        PlayerPrefs.SetInt("mtInventory",Inventory[0]);
        PlayerPrefs.SetInt("smInventory", Inventory[1]);
        PlayerPrefs.SetInt("gmInventory", Inventory[2]);
    }
}
