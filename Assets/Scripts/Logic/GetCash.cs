using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCash : MonoBehaviour
{
    [SerializeField] private int multitly=1;
    public static GetCash instance;

    public int Cash { get; private set; }
    public static GetCash Instance { get => instance; }


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

    }
    void Start()
    {
        
    }
    public void CashValue(bool winOfail)
    {
        if (winOfail)
        {
            Cash = (50 + (int)GameController.Instance.WardTime) * multitly;
        }
        PlayerInventory.instance.MyMoney += Cash;
    }
    public void ChangeMultitly() 
    {
        multitly = 2;
    }

}
