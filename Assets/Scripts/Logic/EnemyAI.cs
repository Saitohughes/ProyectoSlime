using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : IA
{
    [SerializeField] GameObject vision;
     AudioSource mySource;
    //public override void Awake()
    //{
    //    pathFinder=GetComponent<PathFinder>();
    //}

    private void Start()
    {
        mySource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    public override void ChangeTransform(Transform target)
    {

        pathFinder.target = target;
        vision.SetActive(false);
        mySource.Play();
    }

    
}
