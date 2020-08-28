using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsObject : MonoBehaviour
{
    [SerializeField] float time;

    [SerializeField] bool shakeCamera;
    [SerializeField] [Range(0f, 1f)] float duration;
    [SerializeField] [Range(0f, 1f)] float magnitude;

    // Start is called before the first frame update
    void Start()
    {
        if (shakeCamera)
        {
            Destroy(gameObject, time);
        }
    }
}
