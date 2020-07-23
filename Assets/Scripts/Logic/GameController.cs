using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject friend;
    void Start()
    {
        friend = GameObject.FindGameObjectWithTag("Friend");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            friend.GetComponent<FriendAI>().StateModification(1);
        }
        if (Input.GetKey(KeyCode.E))
        {
            friend.GetComponent<FriendAI>().StateModification(2);
        }
    }
}
