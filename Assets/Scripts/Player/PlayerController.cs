using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
   
    

    [SerializeField] private string instruction;
    [SerializeField] private float time,meltTime;
    [SerializeField] private GameObject interact,armature;
    [SerializeField] private bool mylife, see;
    [SerializeField] private AudioSource mySource;
    [SerializeField] private AudioClip[] myClips;
    private int count;
    public static PlayerController instance;
    public static PlayerController Instance { get => instance; }
    public string Instruction { get => instruction; private set => instruction = value; }

    public bool acction;
    public Joystick joystick;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
        mySource = GameObject.FindGameObjectWithTag("VFX").GetComponent<AudioSource>();
        
    }
    void Start()
    {
        see = false;
        mylife = true;
      
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
                PlayerMovement.Instance.CanHead(true);
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
        count = 0;
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
                if(!mySource.isPlaying)
                {
                    if(count == 0)
                    {
                        count += 1;
                        mySource.PlayOneShot(myClips[0],0.2f);
                    }
                }
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
                if (count == 0)
                {
                    count += 1;
                    mySource.PlayOneShot(myClips[1], 0.2f);
                }
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
                if (count == 0)
                {
                    count += 1;
                    mySource.PlayOneShot(myClips[2], 1f);
                }
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
                if (count == 0)
                {
                    count += 1;
                    mySource.PlayOneShot(myClips[3], 0.01f);
                }
            }
        }
            
        
    }

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
            GameController.instance.GameOver(mylife);
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
