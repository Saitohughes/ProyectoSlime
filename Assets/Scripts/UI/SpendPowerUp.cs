using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpendPowerUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] inventory;
    [SerializeField] private PlayerInventory myInventory;

    private int count;

    public void Awake()
    {
        Actualize();

        for (int i = 0; i < inventory.Length; i++)
        {
            if (myInventory.Inventory[i] <= 0)
            {
                count += 1;
            }
        }

        if(count == 3)
        {
            gameObject.SetActive(false);
        }
    }


    public void Actualize()
    {
        count = 0;
        myInventory = FindObjectOfType<PlayerInventory>();

        for (int i = 0; i < myInventory.Inventory.Length; i++)
        {
            inventory[i].text = ("x" + myInventory.Inventory[i]);
        }
    }

    public void UseHandicap(int handicapSelected)
    {
        myInventory.Inventory[handicapSelected] -= 1;
        Actualize();
        gameObject.SetActive(false);
    }

}
