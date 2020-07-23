using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerMovement playerMov;
    Rigidbody myRig;
    BoxCollider myCollider;

    
    private void Awake()
    {
          myCollider = GetComponent<BoxCollider>();
          playerMov = FindObjectOfType<PlayerMovement>();
          myRig = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Grab(GameObject player) //metodo que se encarga de agarrar la caja
    {
        if (player != null && myRig != null)
        {
            gameObject.transform.parent = player.transform;
            playerMov.ChangeSpeed(2);
            gameObject.layer = 9; 
            //myRig.isKinematic = false;
        }
    }

    public void NoGrab() //funcion que se encarga de soltar la caja
    {
        if(myRig != null) 
        {
            gameObject.transform.parent = null;
            playerMov.RestoreSpeed();
            gameObject.layer = 11;
            //myRig.isKinematic = true;
        }
    }
}
