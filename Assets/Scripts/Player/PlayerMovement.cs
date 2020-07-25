using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed, originalSpeed; //variabñle que va a controlar la velocidad del personaje
    [SerializeField] Rigidbody myRig; //componente necesaria
    Vector3 mov; //vector de movimiento
    // Start is called before the first frame update
    private void Awake()
    {
        originalSpeed = speed;
        myRig =gameObject.GetComponent<Rigidbody>(); //Se define el valor de la componente que vamos a modificar 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
   
    void FixedUpdate()
    {
        mov = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed); //le damos el valor al vector con respecto a las direcciones
        myRig.velocity = mov; //aqui usamos Velocity para darle el vector que ya definimos
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
