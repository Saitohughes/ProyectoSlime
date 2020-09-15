using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBox : MonoBehaviour
{
    [SerializeField] ParticleSystem melt;
    [SerializeField] GameObject visualmelt;

    // Start is called before the first frame update

    public void Melt()
    {
        OffVisualMelt();
        gameObject.SetActive(false);
        Instantiate(melt, transform.position, Quaternion.identity);
        Destroy(gameObject,2f);
    }
    void OffVisualMelt()
    {
        visualmelt.SetActive(false);
    }
    void OnVisualMelt()
    {
        visualmelt.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {

            if (PlayerController.Instance.acction == true)
            {
                OnVisualMelt();
            }
            else
            {
                OffVisualMelt();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            OffVisualMelt();
        }
    }
}
