using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCount : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int mycount;

    public static LevelCount instance;

    public static LevelCount Instance { get => instance; }
    // Update is called once per frame
    private void Awake()
    {
        
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
       // PlayerPrefs.DeleteAll();
        DontDestroyOnLoad(gameObject);
        mycount = PlayerPrefs.GetInt("turorialProgress", mycount); ;
    }

    public int Mycount { get => mycount; }
    public void UpdateCount()
    {
        mycount++;
        PlayerPrefs.SetInt("turorialProgress", mycount);
    }
}
