using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string instruction;
    [SerializeField] float time;
    [SerializeField] GameObject interact;
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
                //interact.GetComponent<BoxMove>().NoGrab();
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
            if (interact.CompareTag("Box"))
            {
                interact.GetComponent<BoxMove>().NoGrab();
            }
            interact = null;
            time = 0;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
       

    }

    private void OnTriggerEnter(Collision collision)
    {
        
    }
   
    private void OnTriggerStay(Collider collision)
    {
        //interact = collision.gameObject;
        if (collision.gameObject.CompareTag("Box") && Input.GetKeyDown(KeyCode.P))
        {
            
            if (instruction != "Null")
            {
                instruction = "Null";
            }
            else if(instruction.Equals("Null"))
            {
                interact = collision.gameObject;
                interact.GetComponent<BoxMove>().Grab(gameObject);
                instruction = "Box";
            }
        }
        else if(collision.gameObject.CompareTag("Metal") && Input.GetKeyDown(KeyCode.P))
        {
            if (instruction != "Null")
            {
                instruction = "Null";
            }
            else if(instruction.Equals("Null"))
            {
                interact = collision.gameObject;
                instruction = "Metal";
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == interact.gameObject.tag)
        {
            instruction = "Null";
        }
        
    }

}
