using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerMovement playerMov;
    BoxCollider myCollider;
    [SerializeField] bool grab = false;
    
    private void Awake()
    {
          myCollider = GetComponent<BoxCollider>();
          playerMov = FindObjectOfType<PlayerMovement>();
        
          //myRig = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (grab == true)
        {
            if (GetComponentInParent<PlayerController>().GetInstrucction().Equals("Null"))
                NoGrab();
        }
    }

    public void Grab(GameObject player) //metodo que se encarga de agarrar la caja
    {
        if (player != null)
        {
            gameObject.transform.parent = player.transform;
            playerMov.ChangeSpeed();
            gameObject.layer = 10;
            grab = true;
        }
    }

    public void NoGrab() //funcion que se encarga de soltar la caja
    {
        //GetComponentInParent<PlayerController>().ChangeAcction(false);
        gameObject.transform.parent = null;
        playerMov.RestoreSpeed();
        gameObject.layer = 11;
        grab=false;



    }
}
