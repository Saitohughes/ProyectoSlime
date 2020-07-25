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
          //myRig = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Grab(GameObject player) //metodo que se encarga de agarrar la caja
    {
        if (player != null)
        {
            gameObject.transform.parent = player.transform;
            playerMov.ChangeSpeed(2);
          
        }
    }

    public void NoGrab() //funcion que se encarga de soltar la caja
    {
        gameObject.transform.parent = null;
        playerMov.RestoreSpeed();
    }
}
