using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UIElements;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] FriendAI friend;
    [SerializeField] GameObject win, lost,hud;
    [SerializeField] TextMeshProUGUI timeCount;
    [SerializeField] List<GameObject> enemys;
    [SerializeField] float timeStart, time;
    [SerializeField] bool go = false, oneTime, start;
    [SerializeField] float wardTime;
    [SerializeField] Button skipVelocity;
    PlayerMovement myMov;
    private void Awake()
    {
        myMov = FindObjectOfType<PlayerMovement>();
    }
    void Start()
    {
        timeStart = time;
        timeCount.text = time.ToString("F0");
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
   public void StartGame()
    {
        if (oneTime == false)
        {
            friend.StateModification(1);
            PuzzleActive();
            go = true;
            oneTime = true;
            PlayerMovement.Instance.ChangeSpeed(0f);
            skipVelocity.gameObject.SetActive(true);
        }
    }
   public void SkipMovement(float velocity = 2)
    {
        Time.timeScale = velocity;
    }
 
    public void Timer()
    {
        timeStart -= Time.deltaTime;
        if(timeStart >= 0)
        {
            timeCount.text = timeStart.ToString("F0");
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
            if (enemys[i] != null)
            {
                enemys[i].layer = 9; 
            }
        }
    }
    public void GameOver(bool stop)
    {
        SkipMovement(1);
        if (stop)
        {
            Win();
        }
        else
        {
            Lost();
        }  
    }
    void Update()
    {
        if (timeStart > 0 || go)
        {   
            Timer();
        }
       /* if (Input.GetKey(KeyCode.R))
        {
            StartButtom();
        }*/
        /*
        if (Input.GetKey(KeyCode.E))
        {
            PuzzleActive();
        }
        */
    }

    public void Win()
    {
        win.SetActive(true);
        LevelCount.Instance.UpdateCount();
        hud.SetActive(false);
        myMov.ChangeSpeed(0);

    }
    public void Lost()
    {
        lost.SetActive(true);
        hud.SetActive(false);
        myMov.ChangeSpeed(0);
    }

     
}

