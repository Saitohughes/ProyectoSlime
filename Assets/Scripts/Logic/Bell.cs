using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    [SerializeField] GameObject guard, effect;

    public void CallGuard()
    {
        guard.gameObject.GetComponent<EnemyAI>().StateModification(1);
        effect.SetActive(false);
    }
}
