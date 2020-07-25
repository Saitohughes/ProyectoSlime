using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string instruction;
    GameObject placeholder;

    void Start()
    {
        instruction = "null";
    }

    // Update is called once per frame
    void Update()
    {
        if (instruction.Equals("Box"))
        {
             if (Input.GetKeyUp(KeyCode.P) && placeholder != null)
            {
                placeholder.GetComponent<BoxMove>().NoGrab();
                instruction = "null";
            }
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
       

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box") && Input.GetKeyDown(KeyCode.P))
        {
            collision.gameObject.GetComponent<BoxMove>().Grab(gameObject);
            instruction = "Box";
            placeholder = collision.gameObject;
        }
        

    }
    
}
