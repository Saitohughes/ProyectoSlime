using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PitController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject boxField, deathFloor;
    private Collider myCol;
    private void Awake()
    {
        myCol = GetComponent<Collider>();
    }
    void Start()
    {
       boxField.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            other.gameObject.GetComponent<BoxMove>().NoGrab();
            other.gameObject.SetActive(false);
            deathFloor.SetActive(false);
            boxField.SetActive(true);
            myCol.enabled = false;
            Destroy(other);
        }
                    
    }
}
