using System.Collections;
using System.Collections.Generic;
//using UnityEditor.U2D;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed, originalSpeed, horizontal, vertical; //variabñle que va a controlar la velocidad del personaje
    [SerializeField] Rigidbody myRig; //componente necesaria
    Animator myAnim;

    public Joystick joystick;

    Vector3 mov; //vector de movimiento
    Vector3 desf;
    // Start is called before the first frame update
    private void Awake()
    {
        originalSpeed = speed;
        myRig =gameObject.GetComponent<Rigidbody>(); //Se define el valor de la componente que vamos a modificar 
        myAnim = GetComponentInChildren<Animator>();
    }
  

    // Update is called once per frame
   
    void FixedUpdate()
    {
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;

        desf = new Vector3(1f,0,1f);

        mov = new Vector3(horizontal * speed, 0, vertical * speed); //le damos el valor al vector con respecto a las direcciones
        //mov = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        myRig.velocity = mov ; //aqui usamos Velocity para darle el vector que ya definimos
       
        

        if (mov.magnitude > 0)
            myAnim.SetBool("walk", true);
        else
            myAnim.SetBool("walk", false);
    }

    public void ChangeSpeed(float changeSpeed = 5.5f)
    {
         speed = changeSpeed;
    }
    public void RestoreSpeed()
    {
        speed = originalSpeed;
    }
}
