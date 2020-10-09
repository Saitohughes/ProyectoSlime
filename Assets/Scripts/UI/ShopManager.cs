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

    [Header("Efectos de Sonido Tienda")]
    [SerializeField] private AudioSource mySource;
    [SerializeField] private AudioClip buyItem, cantBuy;

    public void Awake()
    {
        Actualice();
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

    public void Actualice()
    {
        myInventory = FindObjectOfType<PlayerInventory>();
        myMoney.text = myInventory.MyMoney.ToString();

        for (int i = 0; i < myInventory.Inventory.Length; i++)
        {
            priceTxt[i].text = price[i].ToString();
            inventory[i].text = ("x" + myInventory.Inventory[i]);
        }
        myInventory.Actualice();
    }

    public void Buy(int handicapSelected)
    {
        if (myInventory.MyMoney >= price[handicapSelected])
        {
            myInventory.MyMoney -= price[handicapSelected];
            myInventory.Inventory[handicapSelected] += 1;

            Actualice();

            mySource.PlayOneShot(buyItem);
        }
        else
        {
            mySource.PlayOneShot(cantBuy, 0.5f);
        }
    }
}
