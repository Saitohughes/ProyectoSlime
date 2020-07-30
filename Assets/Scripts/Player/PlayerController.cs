using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string instruction;
    [SerializeField] float time;
    [SerializeField] GameObject interact,armature;
    [SerializeField] float meltTime;

    public bool acction;
    public Joystick joystick;

    void Start()
    {
        instruction = "Null";
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (instruction.Equals("Box") && interact != null)
        {
             if ( !acction )
             {
                interact.GetComponent<BoxMove>().NoGrab();
                instruction = "Null";
             }
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
            
            if (vertical > 0 &&  Math.Abs(vertical) > Math.Abs(horizontal))
                OnRotate(0);
            if (vertical < 0 && Math.Abs(vertical) > Math.Abs(horizontal))
                OnRotate(180);
            if (horizontal > 0 && Math.Abs(horizontal) > Math.Abs(vertical))
                OnRotate(90);
            if (horizontal < 0 && Math.Abs(horizontal) > Math.Abs(vertical))
                OnRotate(270);

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

    public void OnRotate(float RotationPosition = 0)
    {
        armature.transform.localRotation = Quaternion.Euler( new Vector3(0, RotationPosition, 0));

    }

    public void myAcction()
    {
        if (acction == false)
            acction = true;
        else if (acction == true)
            acction = false;
    }
}
