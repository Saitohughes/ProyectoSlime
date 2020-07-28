using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanism : MonoBehaviour
{
    [SerializeField] Transform myTransform,minHigh,actualhigh; //par amedir el movimiento tanto de la puerta como hacia donde lo pondremos
    bool descending, releasing; //comfirmamos que se realice el desplazamiento

    // Start is called before the first frame update
    private void Awake()
    {
        myTransform = GetComponent<Transform>();
        descending = false;
        releasing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (descending == true && myTransform.position.y > minHigh.position.y)
        {
            transform.position += new Vector3(0, (1 * -1 * Time.deltaTime), 0);
        }

        if (releasing == true && myTransform.position.y < actualhigh.position.y)
        {
            transform.position += new Vector3(0, (1 * 1 * Time.deltaTime), 0);
        }
    }

    public void OnDescending() // funcion que revisa si esta descendiedno
    {
        descending = true;
        releasing = false;
    }
    public void OnReleasing() //funcion que revisa si esta quieto
    {
        releasing = true;
        descending = false;
    }
}
