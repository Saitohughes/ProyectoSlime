using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject vision;
    [SerializeField] int state = 0; //0 Guard, 1 Exit
    [SerializeField] Transform target;
    [SerializeField] Transform targetGuard;


    PathFinder pathFinder;
    Animator animator;
    AudioSource mySource;


    void Awake()
    {
        pathFinder = GetComponent<PathFinder>();
        //animator = GetComponent<Animator>();
        mySource = GetComponent<AudioSource>();
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

            pathFinder.target = target;

        }

    }

    /// <summary>
    /// Modificador de estados
    /// </summary>
    /// <param name="NewState">0 guarida, 1 objetivo,</param>
    public void StateModification(int NewState) // modifica los estados, desde otros lugares
    {
        state = NewState;
        vision.SetActive(false);
        mySource.Play();
    }
}
