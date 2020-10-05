using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MetalBox : MonoBehaviour
{
    [SerializeField] ParticleSystem melt;
    [SerializeField] GameObject visualmelt;
    [SerializeField] GameObject boxBody;

    public Ease moveEase = Ease.Linear;
    [SerializeField] float time;
    [Range(1f, 0.5f)] public float scale;


    Vector3 originalScale;

    // Start is called before the first frame update
    private void Awake()
    {
        originalScale = transform.localScale;
    }
    public void Melt()
    {
        OffVisualMelt();
        gameObject.SetActive(false);
        Instantiate(melt, transform.position, Quaternion.identity);
        Destroy(gameObject,2f);
    }
    void OffVisualMelt()
    {
        DOTween.Clear();
        //transform.localScale = originalScale;
        visualmelt.SetActive(false);
    }
    void OnVisualMelt()
    {
        visualmelt.SetActive(true);
        DOTween.Sequence().Append(boxBody.transform.DOScale(scale, time)).SetEase(moveEase);
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
