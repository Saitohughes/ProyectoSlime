using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] float vision;
    
    void Update()
    {
        RaycastHit informacion = new RaycastHit();

        if (Physics.Raycast(transform.position, transform.forward, out informacion, vision))
        {
            //Debug.Log("Entre");  
            if (informacion.collider.CompareTag("Friend"))
            {
                 Debug.Log("Collisione con el amigo");
                informacion.collider.GetComponent<FriendAI>().Lose();
            }         
            vision = informacion.distance;
        }
        else
        {
            vision = 10;
            //Debug.Log("No entre");
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward* vision);
    }

}
