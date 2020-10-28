using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialValidador : MonoBehaviour
{
    public static TutorialValidador instance;
    public static TutorialValidador Instance { get => instance; }
    [SerializeField] int count;
    [SerializeField] GameObject tutorial;
    public int Count { get => count; set => count = value; }

    // Start is called before the first frame update
    void Start()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        Count = PlayerPrefs.GetInt("Validador_tutorial");
        if (Count == 0)
        {
            ChangeValidator();
        }
#if UNITY_EDITOR
        //ClearValidator();
#endif
    }

    // Update is called once per frame
    public void ChangeValidator()
    {
        Count = 1;
        tutorial.SetActive(true);
        PlayerPrefs.SetInt("Validador_tutorial", Count);
    }

    public void ClearValidator()
    {
        PlayerPrefs.SetInt("Validador_tutorial", 0);
    }
}
