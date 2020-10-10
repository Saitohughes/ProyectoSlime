using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int myMoney;
    [SerializeField] private int[] inventory;

    public static PlayerInventory instance;

    public static PlayerInventory Instance { get => instance; }
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
        PlayerPrefs.SetInt("playerMoney", 0);
        PlayerPrefs.SetInt("playerMoney", myMoney);

        PlayerPrefs.SetInt("mtInventory", 0);
        PlayerPrefs.SetInt("mtInventory", inventory[0]);

        PlayerPrefs.SetInt("smInventory", 0);
        PlayerPrefs.SetInt("smInventory", inventory[1]);

        PlayerPrefs.SetInt("gmInventory", 0);
        PlayerPrefs.SetInt("gmInventory", inventory[2]);
#endif
        Debug.Log(PlayerPrefs.GetInt("playerMoney"));
        myMoney = PlayerPrefs.GetInt("playerMoney");
        

        inventory[0] = PlayerPrefs.GetInt("mtInventory");
        inventory[1] = PlayerPrefs.GetInt("smInventory");
        inventory[2] = PlayerPrefs.GetInt("gmInventory");
        

    }
    public void Actualice()
    {
        Debug.Log("Actualize el valor");
        PlayerPrefs.SetInt("playerMoney", myMoney);
        PlayerPrefs.SetInt("mtInventory", inventory[0]);
        PlayerPrefs.SetInt("smInventory", inventory[1]);
        PlayerPrefs.SetInt("gmInventory", inventory[2]);
    }
}
