using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [Header("Componentes de la Tienda")]
    [SerializeField] private PlayerInventory myInventory;
    [SerializeField] private TextMeshProUGUI myMoney;

    [Header("Información Productos")]
    [SerializeField] private int[] price;
    [SerializeField] private TextMeshProUGUI[] priceTxt;
    [SerializeField] private TextMeshProUGUI[] inventory;


    public void Awake()
    {
        Actualize();
    }

    public void Update()
    {
        for (int i = 0; i < priceTxt.Length; i++)
        {
            if(myInventory.MyMoney >= price[i])
            {
                priceTxt[i].color = Color.white;
            }
            else
            {
                priceTxt[i].color = Color.red;
            }
        }
    }

    public void Actualize()
    {
        myInventory = FindObjectOfType<PlayerInventory>();
        myMoney.text = myInventory.MyMoney.ToString();

        for (int i = 0; i < myInventory.Inventory.Length; i++)
        {
            priceTxt[i].text = price[i].ToString();
            inventory[i].text = ("x" + myInventory.Inventory[i]);
        }
    }

    public void Buy(int handicapSelected)
    {
        if (myInventory.MyMoney >= price[handicapSelected])
        {
            myInventory.MyMoney -= price[handicapSelected];
            myInventory.Inventory[handicapSelected] += 1;

            Actualize(); 
        }
    }
}
