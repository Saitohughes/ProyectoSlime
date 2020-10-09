using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UIElements;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [SerializeField] FriendAI friend;
    [SerializeField] GameObject win, lost,hud;
    [SerializeField] TextMeshProUGUI timeCount;
    [SerializeField] List<GameObject> enemys;
    [SerializeField] float timeStart, time;
    [SerializeField] bool go = false, oneTime, start;
    [SerializeField] Button skipVelocity;
    PlayerMovement myMov;

    AudioSource mySource, myMusic;
    [SerializeField] AudioClip[] myClips;
    
    [SerializeField] int scene;

    public static GameController instance;

    public static GameController Instance { get => instance; }

    public float WardTime { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        myMov = FindObjectOfType<PlayerMovement>();
        scene = SceneManager.GetActiveScene().buildIndex;
        mySource = gameObject.GetComponent<AudioSource>();
        myMusic = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
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

            mySource.Stop();
            mySource.PlayOneShot(myClips[0]);
        }

    }
   public void SkipMovement(float velocity = 2)
    {
        Debug.Log("se multiplico la velocidad");

        Time.timeScale = velocity;
       
    }
 
    public void Timer()
    {

        timeStart -= Time.deltaTime;
        if(timeStart >= 0)
        {
            timeCount.text = timeStart.ToString("F0");
        }
        else if(timeStart < 0)
        {
            timeCount.text = "0";
        }
        
        if (go && timeStart >= 0)
        {
            WardTime = timeStart;
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
        if(LevelCount.Instance.Mycount < scene)
            LevelCount.Instance.UpdateCount();
        hud.SetActive(false);
        myMov.ChangeSpeed(0);
        GetCash.Instance.CashValue(true);

        myMusic.Stop();
        mySource.PlayOneShot(myClips[1], 1f);
    }
    public void Lost()
    {
        lost.SetActive(true);
        hud.SetActive(false);
        myMov.ChangeSpeed(0);

        myMusic.Stop();
        mySource.PlayOneShot(myClips[2], 1f);
    }
    public void TimerPowerUp()
    {
        timeStart += 30f; 
    }

     
}

