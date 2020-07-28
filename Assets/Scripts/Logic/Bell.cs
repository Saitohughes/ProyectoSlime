using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    [SerializeField] GameObject guard;

    public void CallGuard()
    {
        guard.gameObject.GetComponent<EnemyAI>().StateModification(1);
    }
}
