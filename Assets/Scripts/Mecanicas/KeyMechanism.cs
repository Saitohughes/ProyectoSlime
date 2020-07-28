using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMechanism : MonoBehaviour
{
    [SerializeField] DoorMechanism myDoor;

    private void Awake()
    {
        //myDoor = FindObjectOfType<DoorMechanism>();
    }
    
    public void ActivateDoor()
    {
        myDoor.OnDescending();
        gameObject.SetActive(false);
        Destroy(gameObject, 2f);
    }
}
