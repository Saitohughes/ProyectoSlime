using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
//using UnityEditor.U2D;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public static PlayerMovement Instance { get => instance; }

    [SerializeField] private float speed, originalSpeed, horizontal, vertical; //variabñle que va a controlar la velocidad del personaje
    private  Animator myAnim;
    [SerializeField] private bool canHead = true;
    private Joystick joystick;
    private AudioSource mySource;

    Vector3 mov,forward,right; //vector de movimiento
  
    // Start is called before the first frame update
    private void Awake()
    {
        //Proceso del singleton
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
       
        joystick = FindObjectOfType<FixedJoystick>();

        originalSpeed = speed;
        myAnim = GetComponentInChildren<Animator>();
        mySource = gameObject.GetComponent<AudioSource>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

    }
  

    // Update is called once per frame
   
 
    void Update()
    {
        Movement();
    }

    public void ChangeSpeed(float changeSpeed = 5.5f)
    {
        
        speed = changeSpeed;
        CanHead(false);
    }
    public void RestoreSpeed()
    {
        speed = originalSpeed;
        CanHead(true);
    }

    void Movement()
    {

        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;

        mov = new Vector3(horizontal, 0, vertical); //le damos el valor al vector con respecto a las direcciones
        Vector3 rightMovement = right * speed * Time.deltaTime * horizontal;
        Vector3 forwardMovement = forward * speed * Time.deltaTime * vertical;

        Vector3 heading = Vector3.Normalize(rightMovement + forwardMovement);
        

        if (heading.magnitude != 0 && canHead)
        {
            transform.forward = heading; 
        }

        transform.position += rightMovement;
        transform.position += forwardMovement;

        if (mov.magnitude > 0)
        {
            myAnim.SetBool("walk", true);
            if (!mySource.isPlaying)
                mySource.Play();
        }
        else
        {
            myAnim.SetBool("walk", false);
            mySource.Stop();
        }
    }

    public void CanHead(bool head)
    {
        canHead = head;
    }
}
