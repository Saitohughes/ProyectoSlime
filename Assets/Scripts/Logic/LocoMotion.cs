using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class LocoMotion : MonoBehaviour
{
   private NavMeshAgent agent;
   private Animator animator;
   private Vector2 SmoothDeltaPosition = Vector2.zero;
   private Vector2 velocity= Vector2.zero;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        
    }
    void Update()
    {
        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

        // Map worldDeltaPosition to local space

        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        SmoothDeltaPosition = Vector2.Lerp(SmoothDeltaPosition, deltaPosition, 1);
        velocity = deltaPosition / Time.deltaTime;

        bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

    }
    void OnAnimatorMove()
    {
        transform.position = agent.nextPosition;
    }
 
}
