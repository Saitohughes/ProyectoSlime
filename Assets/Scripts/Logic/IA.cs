using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IA : MonoBehaviour
{
    protected PathFinder pathFinder;
  public virtual void Awake()
    {
        pathFinder = GetComponent<PathFinder>();
        pathFinder.target = gameObject.transform;
    }

    public virtual void ChangeTransform(Transform target)
    {
        pathFinder.target = target;
    }



}
