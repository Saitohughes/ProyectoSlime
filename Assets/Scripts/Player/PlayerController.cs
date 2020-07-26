using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string instruction;
    [SerializeField] float time;
    [SerializeField] GameObject interact,armature;
    [SerializeField] float meltTime;

    void Start()
    {
        instruction = "null";
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (instruction.Equals("Box") && interact != null)
        {
             if (Input.GetKeyUp(KeyCode.P) )
             {
                interact.GetComponent<BoxMove>().NoGrab();
                instruction = "Null";
               

            }
        }

        if (instruction.Equals("Metal") && interact != null)
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                instruction = "Null";
               
            }
            time += Time.deltaTime;
            if (time >= meltTime)
            {
                interact.GetComponent<MetalBox>().Melt();
            }
        }

        if (instruction.Equals("Null"))
        {
            interact = null;
            time = 0;
            armature.layer = 8;

            if (Input.GetAxis("Vertical") > 0)
                OnRotate(0);
            if (Input.GetAxis("Vertical") < 0)
                OnRotate(180);
            if (Input.GetAxis("Horizontal") > 0)
                OnRotate(90);
            if (Input.GetAxis("Horizontal") < 0)
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
            if (collision.gameObject.CompareTag("Box") && Input.GetKeyDown(KeyCode.P))
            {
                interact = collision.gameObject;
                interact.GetComponent<BoxMove>().Grab(gameObject);
                instruction = "Box";
                armature.layer = 9;

            }
            else if (collision.gameObject.CompareTag("Metal") && Input.GetKeyDown(KeyCode.P))
            {
                interact = collision.gameObject;
                instruction = "Metal";
                armature.layer = 9;
            }
        }
    }

    public void OnRotate(float RotationPosition = 0)
    {
        armature.transform.localRotation = Quaternion.Euler( new Vector3(0, RotationPosition, 0));

    }
}
