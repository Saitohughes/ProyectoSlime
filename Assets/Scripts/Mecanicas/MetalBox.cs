using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBox : MonoBehaviour
{
    [SerializeField] ParticleSystem melt;
    // Start is called before the first frame update
    public void Melt()
    {
        gameObject.SetActive(false);
        Instantiate(melt, transform.position, Quaternion.identity);
        Destroy(gameObject,2f);
    }
}
