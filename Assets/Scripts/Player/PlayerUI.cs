using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Image box;
    [SerializeField] Image metal;
    [SerializeField] Image bell;
    [SerializeField] Image key;

    [SerializeField] TextMeshProUGUI textInteraction;

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
            textInteraction.text = "Grab";
        }
        else if(player.GetComponent<PlayerController>().GetInstrucction() == "Bell")
        {
            bell.enabled = true;
            textInteraction.text = "Touch";
        }
        else if (player.GetComponent<PlayerController>().GetInstrucction() == "Key")
        {
            key.enabled = true;
            textInteraction.text = "Active";
        }
        else if (player.GetComponent<PlayerController>().GetInstrucction() == "Metal")
        {
            metal.enabled = true;
            textInteraction.text = "Melt";
        }
        else
        {
            box.enabled = false;
            bell.enabled = false;
            metal.enabled = false;
            key.enabled = false;
            textInteraction.text = null;
        }
    }

}
