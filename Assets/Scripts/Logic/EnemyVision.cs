using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{

    public GameObject objectCollision;
    [SerializeField] float vision, sphereRadius;
    public LayerMask layerMask;

    private Vector3 origin;
    private Vector3 direction;

    private float currentHitDistance;


    void Update()
    {
        origin = transform.position;
        direction = transform.forward;
        RaycastHit informacion;

        if (Physics.SphereCast(origin,sphereRadius,direction,out informacion, vision, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            objectCollision = informacion.transform.gameObject;
            currentHitDistance = informacion.distance;
            Debug.Log("Entre");  
            if (informacion.collider.CompareTag("Friend"))
            {
                Debug.Log("Collisione con el amigo");
                informacion.collider.GetComponent<FriendAI>().Lose();
            }         
            //vision = informacion.distance;
        }
        else
        {
            currentHitDistance = vision;
            objectCollision = null;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    }
  
}
