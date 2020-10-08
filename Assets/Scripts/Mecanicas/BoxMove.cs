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
    [SerializeField] GameObject help;
    AudioSource mySource;
    
    private void Awake()
    {
        myCollider = GetComponent<BoxCollider>();
        playerMov = FindObjectOfType<PlayerMovement>();
        mySource = gameObject.GetComponent<AudioSource>();
        
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
            PlayerMovement.Instance.ChangeSpeed();
            gameObject.layer = 10;
            grab = true;

            if (!mySource.isPlaying)
                mySource.Play();
        }
    }

    public void NoGrab() //funcion que se encarga de soltar la caja
    {
        //GetComponentInParent<PlayerController>().ChangeAcction(false);
        gameObject.transform.parent = null;
        PlayerMovement.Instance.RestoreSpeed();
        gameObject.layer = 11;
        grab=false;
        mySource.Stop();
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
           
            if (help != null)
                help.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            if (help != null)
                help.SetActive(true);
        }
    }
    */
}
