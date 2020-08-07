using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] float vision;
    void Start()
    {
        
    }
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
   
        Debug.DrawRay(ray.origin, ray.direction*vision,Color.red);

        RaycastHit informacion = new RaycastHit();

        if (Physics.Raycast(ray, out informacion, vision))
        {
            if (informacion.collider.CompareTag("Friend"))
            {
                Debug.Log("Collisione con el amigo");
                informacion.collider.GetComponent<FriendAI>().Lose();
            }
        }
    }
}
