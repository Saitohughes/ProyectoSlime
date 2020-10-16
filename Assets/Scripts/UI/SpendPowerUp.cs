using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SpendPowerUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] inventory;
    [SerializeField] GameObject hud;
    [SerializeField] GameObject friend;
    [SerializeField] private int count;

    public void Start()
    {
        Actualice();
        hud.SetActive(false);
        Time.timeScale = 0;

        for (int i = 0; i < inventory.Length; i++)
        {
            if (PlayerInventory.Instance.Inventory[i] == 0)
            {
                count += 1;
                Debug.Log("entre al contador");
            }
        }

        if(count == 3)
        {
            Close();
        }
        friend = GameObject.FindGameObjectWithTag("Friend");
    }


    public void Actualice()
    {
        count = 0;
        Debug.Log(PlayerInventory.Instance.Inventory.Length);
        //myInventory = FindObjectOfType<PlayerInventory>();

        for (int i = 0; i < PlayerInventory.Instance.Inventory.Length; i++)
        {
            inventory[i].text = ("x" + PlayerInventory.Instance.Inventory[i]);
        }
    }

    public void UseHandicap(int handicapSelected)
    {

        PlayerInventory.Instance.Inventory[handicapSelected] -= 1;
        PlayerInventory.Instance.Actualice();
        Actualice();
        if (handicapSelected == 0)
        {
            GameController.Instance.TimerPowerUp();
        }
        else if(handicapSelected == 1)
        {
            friend.AddComponent<Shield>();
        }
        else if(handicapSelected == 2)
        {
            GetCash.Instance.ChangeMultitly();
        }

        Close();
    }

    public void Close()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        hud.SetActive(true);
    }

}
