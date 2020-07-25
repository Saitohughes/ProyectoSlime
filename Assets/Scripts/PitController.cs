using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PitController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject boxField;
    Collider myCol;
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
            other.gameObject.SetActive(false);
            boxField.SetActive(true);
            myCol.enabled = false;
            Destroy(other, 2f);
        }
                    
    }
}
