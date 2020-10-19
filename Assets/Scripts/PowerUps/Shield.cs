using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public static Shield instance;

    public static Shield Instance { get => instance; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 9 && collision.gameObject.tag != "Metal")
        {
            collision.gameObject.SetActive(false);
            DestroyMe();
        }
        else if (collision.gameObject.CompareTag("Metal"))
        {
            collision.gameObject.GetComponent<MetalBox>().Melt();
            DestroyMe();
        }

    }
    public void DestroyMe()
    {
        Destroy(this);
    }
}
