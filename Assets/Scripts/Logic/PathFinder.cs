using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    
    NavMeshAgent agent;

    [SerializeField] public Transform target;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
       agent.SetDestination(target.position);
    }
}
