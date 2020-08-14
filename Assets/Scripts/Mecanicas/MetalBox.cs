using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBox : MonoBehaviour
{
    // Start is called before the first frame update
    public void Melt()
    {
        gameObject.SetActive(false);
        Destroy(gameObject,2f);
    }
}
