using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] FriendAI friend;
    [SerializeField] GameObject win, lost, buttom;
    [SerializeField] Text timeCount;
    [SerializeField] List<GameObject> enemys;
    [SerializeField] float timeStart, time;
    [SerializeField] bool go = false, oneTime, start;
    [SerializeField] float wardTime;

    void Start()
    {
    
        timeStart = time;
        timeCount.text = time.ToString();
        start = true;
        friend = FindObjectOfType<FriendAI>();
        var goArray = FindObjectsOfType<GameObject>();
        for (var i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].gameObject.layer == 11)
            {
               enemys.Add(goArray[i].gameObject); 
            }
        }
    }
    void StartGame()
    {
        friend.StateModification(1);
        PuzzleActive();
    }
    void StartButtom()
    {
        if (oneTime == false)
        {
            go = true;
            oneTime = true;
        }
    }
    public void Timer()
    {
        timeStart -= Time.deltaTime;
        if(timeStart >= 0)
        {
            timeCount.text = timeStart.ToString();
        }
        if(timeStart < 0)
        {
            timeCount.text = "0";
        }
        
        if (go && timeStart >= 0)
        {
            wardTime = timeStart;
            timeStart = 0;
            go = false;
        }
        if(timeStart <= 0 && start == true)
        {
            
            StartGame();
            start = false;
        }
    }
    void PuzzleActive()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].layer = 9;
        }
    }
    public void GameOver(bool stop)
    {
        if (stop)
        {
            win.SetActive(true);
            buttom.SetActive(true);
        }
        else
        {
            lost.SetActive(true);
            buttom.SetActive(true);
        }  
    }
    void Update()
    {
        if (timeStart > 0)
        {   
            Timer();
        }
        if (Input.GetKey(KeyCode.R))
        {
            StartButtom();
        }
        /*
        if (Input.GetKey(KeyCode.E))
        {
            PuzzleActive();
        }
        */
    }
}

