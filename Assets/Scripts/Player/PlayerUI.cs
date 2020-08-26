using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Image box;
    [SerializeField] Image metal;
    [SerializeField] Image bell;
    [SerializeField] Image key;

    [SerializeField] GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    public void Update()
    {
        if(player.GetComponent<PlayerController>().GetInstrucction() == "Box")
        {
            box.enabled = true;
        }
        else if(player.GetComponent<PlayerController>().GetInstrucction() == "Bell")
        {
            bell.enabled = true;
        }
        else if (player.GetComponent<PlayerController>().GetInstrucction() == "Key")
        {
            key.enabled = true;
        }
        else if (player.GetComponent<PlayerController>().GetInstrucction() == "Metal")
        {
            metal.enabled = true;
        }
        else
        {
            box.enabled = false;
            bell.enabled = false;
            metal.enabled = false;
            key.enabled = false;
        }
    }

}
