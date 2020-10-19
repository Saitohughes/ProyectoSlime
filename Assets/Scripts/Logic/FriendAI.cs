using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendAI : IA
{
    [SerializeField] bool mylife, win;

    [SerializeField] GameObject confetti,shield;
    Animator animator;
    AudioSource mySource;

     public override void Awake()
    {
        mylife = true;
        pathFinder = GetComponent<PathFinder>();
        animator = GetComponent<Animator>();
        mySource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Shield>() != null)
            shield.SetActive(true);
        else
            shield.SetActive(false);
    }
    public override void ChangeTransform(Transform target)
    {
        pathFinder.target = target;
        mySource.Play();

        if(target != gameObject.transform)
            animator.SetBool("Move", true);
        else
            animator.SetBool("Move", false);
        
        if (mySource.isPlaying)
            mySource.Stop();
    }

    public bool Stop()
    {
        return mylife;
    }
    public void Lose()
    {
        if (gameObject.GetComponent<Shield>() == null)
        {
            mylife = false;
            ChangeTransform(gameObject.transform);
            GameController.Instance.GameOver(Stop());
        }
        else
        {
            Shield.Instance.DestroyMe();
        }
    }
    public void Win()
    {
        ChangeTransform(gameObject.transform);
        confetti.SetActive(true);
        GameController.Instance.GameOver(Stop());

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
