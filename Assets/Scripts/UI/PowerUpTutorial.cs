using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTutorial : MonoBehaviour
{
    [SerializeField] GameObject time, shield, multiply;

    public void Active(int tipo=0)
    {
        if(tipo == 0)
        {
            time.SetActive(true);
        }
        else if(tipo == 1)
        {
            shield.SetActive(true);
        }
        else if(tipo == 2)
        {
            multiply.SetActive(true);
        }
    }
    
}
