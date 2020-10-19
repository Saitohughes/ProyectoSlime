using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    [SerializeField] GameObject  effect;
    [SerializeField] EnemyAI guard;
  
    public void CallGuard()
    {
        guard.ChangeTransform(gameObject.transform);
        effect.SetActive(false);
    }
}
