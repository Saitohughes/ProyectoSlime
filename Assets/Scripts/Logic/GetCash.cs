using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCash : MonoBehaviour
{
    [SerializeField] private int multitly = 1;
    
    public static GetCash instance;
    public static GetCash Instance { get => instance; }

    public int Cash { get; private set; }
    public int LastCash { get; private set; }
    
    public int Multitly { get => multitly; set => multitly = value; }

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
    public void CashValue(bool winOfail)
    {
        if (winOfail)
        {
            LastCash = PlayerInventory.Instance.MyMoney;
            Cash = (50 + (int)GameController.Instance.WardTime) * multitly;
        }
        PlayerInventory.Instance.MyMoney += Cash;
        ScoreManager.Instance.ShowCash();
        PlayerInventory.Instance.Actualice();
    }
    public void ChangeMultitly() 
    {
        multitly = 2;
    }

}
