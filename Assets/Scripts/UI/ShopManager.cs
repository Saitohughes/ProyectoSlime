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



    private void Start()
    {
        Actualice();

    }

    public void Update()
    {
        for (int i = 0; i < priceTxt.Length; i++)
        {
            if(PlayerInventory.Instance.MyMoney >= price[i])
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
        //myInventory = FindObjectOfType<PlayerInventory>();
        myMoney.text = PlayerInventory.Instance.MyMoney.ToString();

        for (int i = 0; i < PlayerInventory.Instance.Inventory.Length; i++)
        {
            priceTxt[i].text = price[i].ToString();
            inventory[i].text = ("x" + PlayerInventory.Instance.Inventory[i]);
        }
        PlayerInventory.Instance.Actualice();
    }

    public void Buy(int handicapSelected)
    {
        if (PlayerInventory.Instance.MyMoney >= price[handicapSelected])
        {
            PlayerInventory.Instance.MyMoney -= price[handicapSelected];
            PlayerInventory.Instance.Inventory[handicapSelected] += 1;

            Actualice();

            mySource.PlayOneShot(buyItem);
        }
        else
        {
            mySource.PlayOneShot(cantBuy, 0.5f);
        }
    }
}
