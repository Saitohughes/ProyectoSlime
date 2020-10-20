using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValidator : MonoBehaviour
{
    public static PlayerValidator instance;
    public static PlayerValidator Instance { get => instance; }
    [SerializeField] int count;
  
    public int Count { get => count; set => count = value; }

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        //ClearValidator();
#endif
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        Count = PlayerPrefs.GetInt("Validador");
       // ClearValidator();
            
    }

    // Update is called once per frame
    public void ChangeValidator()
    {
        Count = 1;
        PlayerPrefs.SetInt("Validador", Count);  
    }

    public void ClearValidator()
    {
        PlayerPrefs.SetInt("Validador", 0);
    }
}
