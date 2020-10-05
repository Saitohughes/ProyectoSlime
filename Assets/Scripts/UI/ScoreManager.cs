using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public static ScoreManager Instance { get => instance; }
    [SerializeField] TextMeshProUGUI multiply, time, level, total, lastCash;
   
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
    public void ShowCash()
    {
        lastCash.text = GetCash.Instance.LastCash.ToString();
        multiply.text = GetCash.Instance.Multitly.ToString();
        time.text = ((int)GameController.Instance.WardTime).ToString();
        level.text = "10";
        total.text = PlayerInventory.instance.MyMoney.ToString();
    }
}
