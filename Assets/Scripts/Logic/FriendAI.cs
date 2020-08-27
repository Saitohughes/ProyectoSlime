using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendAI : MonoBehaviour
{
    GameController myController;
    [SerializeField] int state = 0; //0 Guard, 1 Exit
    [SerializeField] bool mylife, win;
    [SerializeField] Transform targetSafe;
    [SerializeField] Transform myself;
    [SerializeField] Transform targetGuard;
    

    PathFinder pathFinder;
    Animator animator;


    void Awake()
    {
        mylife = true;
        myController = FindObjectOfType<GameController>();
        pathFinder = GetComponent<PathFinder>();
        //animator = GetComponent<Animator>();
        targetSafe = GameObject.FindGameObjectWithTag("Exit").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (state == 0) // dejeme solo
        {
            pathFinder.target = targetGuard;

        }
        else if (state == 1) // follow
        {

            pathFinder.target = targetSafe;

        }
        else if (state == 2) //Dead
        {
            pathFinder.target = myself;
        }

    }

    /// <summary>
    /// Modificador de estados
    /// </summary>
    /// <param name="NewState">0 guarida, 1 objetivo, 2 muerto</param>
    public void StateModification(int NewState) // modifica los estados, desde otros lugares
    {
        state = NewState;
    }

    public bool Stop()
    {
        return mylife;
    }
    public void Lose()
    {
        mylife = false;
        StateModification(2);
        myController.GameOver(Stop());
    }
    public void Win()
    {
        
        StateModification(2);
        myController.GameOver(Stop());
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 9 || collision.gameObject.tag == "DeathFloor")
        {
            Lose();
        }
        if (collision.gameObject.layer == 12)
        {
            collision.collider.enabled = false;
            Win();
        }
    }

}
