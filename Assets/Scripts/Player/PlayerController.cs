using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
   
    GameController myController;

    [SerializeField] string instruction;
    [SerializeField] float time;
    [SerializeField] GameObject interact,armature;
    [SerializeField] float meltTime;
    [SerializeField] bool mylife, see;
    PlayerMovement myMov;
    public static PlayerController instance;
    public static PlayerController Instance { get => instance; }

    public bool acction;
    public Joystick joystick;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
        myMov = GetComponent<PlayerMovement>();
        
    }
    void Start()
    {
        see = false;
        mylife = true;
        myController = FindObjectOfType<GameController>();
        instruction = "Null";
        time = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //linea de testing
#if UNITY_EDITOR
        acction = Input.GetKey(KeyCode.Q); 
#endif


        if (acction == false && see== false)
            if (instruction.Equals("Box") && interact != null)
            { 
                Debug.Log("sali");
                myMov.CanHead(true);
                interact.GetComponent<BoxMove>().NoGrab();
                instruction = "Null";
            }

        if (instruction.Equals("Metal") && interact != null)
        {
            if (!acction && !see)
            {
                instruction = "Null";
            }
        }

       if (instruction.Equals("Null"))
        {
            
            interact = null;
            time = 0;
            armature.layer = 8;
            float vertical = joystick.Vertical;
            float horizontal = joystick.Horizontal;
            
      
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(instruction != "Null")
        {
            instruction = "Null";
            interact = null;
            see = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 11)
        {
            see = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {

            //interact = collision.gameObject;
            if(collision.gameObject.CompareTag("Box"))
            {
                instruction = "Box";
                interact = collision.gameObject; 
                if (acction)
                {
                    Debug.Log("ACTIVE");
                    see = false;
                    interact.GetComponent<BoxMove>().Grab(gameObject);
                    armature.layer = 9; 
                }

            }
            else if (collision.gameObject.CompareTag("Metal"))
            {
                instruction = "Metal";
                interact = collision.gameObject;
                if (acction)
                {
                    Debug.Log("ACTIVE");
                    //armature.layer = 9;
                    time += Time.deltaTime;                 
                    if (time >= meltTime)
                    {
                        acction = false;
                        interact.GetComponent<MetalBox>().Melt();
                        see = false;
                    }
               
                }
            }
            else if(collision.gameObject.CompareTag("Key"))
            {
                instruction = "Key";

                if (acction)
                {
                    Debug.Log("ACTIVE");
                    collision.gameObject.GetComponent<KeyMechanism>().ActivateDoor();
                    instruction = "Null";
                    acction = false;
                    see = false;
                }
            }
            else if(collision.gameObject.CompareTag("Bell"))
            {
                instruction = "Bell";
                if (acction)
                {
                    Debug.Log("ACTIVE");
                    collision.gameObject.GetComponent<Bell>().CallGuard();
                    instruction = "Null";
                    collision.gameObject.layer = 9;
                    acction = false;
                    see = false;
                }
            }
            
        
    }

  /*  public void OnRotate(float RotationPosition = 0)
    {
        armature.transform.localRotation = Quaternion.Euler( new Vector3(0, RotationPosition, 0));

    }
  */

    public void TrueAction()
    { 
        acction = true;
    }
    public void FalseAction()
    {
        acction = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DeathFloor")
        {
            mylife = false;
            myController.GameOver(mylife);
        }
    }
    public void ChangeAcction(bool action)
    {
        acction = action;
    }
    public string GetInstrucction()
    {
        return instruction;
    }
  

}
