using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    GameController myController;

    [SerializeField] string instruction;
    [SerializeField] float time;
    [SerializeField] GameObject interact,armature;
    [SerializeField] float meltTime;
    [SerializeField] bool mylife;
    PlayerMovement myMov;


    public bool acction;
    public Joystick joystick;
    private void Awake()
    {
        myMov = GetComponent<PlayerMovement>();
    }
    void Start()
    {
        mylife = true;
        myController = FindObjectOfType<GameController>();
        instruction = "Null";
        time = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //linea de testing
        acction = Input.GetKey(KeyCode.Q);

        if (acction == false)
            if (instruction.Equals("Box") && interact != null)
            { 
                Debug.Log("sali");
                myMov.CanHead(true);
                interact.GetComponent<BoxMove>().NoGrab();
                instruction = "Null";
             }

        if (instruction.Equals("Metal") && interact != null)
        {
            if (!acction)
            {
                instruction = "Null";
               
            }
            time += Time.deltaTime;
            if (time >= meltTime)
            {
                acction = false;
                interact.GetComponent<MetalBox>().Melt();
                acction = false;
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

   
    private void OnTriggerStay(Collider collision)
    {
        if (instruction != "Null")
        {
            instruction = "Null";
        }
        else if (instruction.Equals("Null"))
        {
           
            //interact = collision.gameObject;
            if (collision.gameObject.CompareTag("Box") && acction )
            {
                interact = collision.gameObject;
                interact.GetComponent<BoxMove>().Grab(gameObject);
                instruction = "Box";
                armature.layer = 9;

            }
            else if (collision.gameObject.CompareTag("Metal") && acction )
            {
                interact = collision.gameObject;
                instruction = "Metal";
                armature.layer = 9;
            }
            else if(collision.gameObject.CompareTag("Key") && acction)
            {
                collision.gameObject.GetComponent<KeyMechanism>().ActivateDoor();
                instruction = "Null";
                acction = false;
            }
            else if(collision.gameObject.CompareTag("Bell") && acction)
            {
                collision.gameObject.GetComponent<Bell>().CallGuard();
                instruction = "Null";
                collision.gameObject.layer = 9;
                acction = false;
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
