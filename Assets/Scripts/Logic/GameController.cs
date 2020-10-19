using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UIElements;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
     private FriendAI friend;
    [SerializeField] private GameObject win, lost, hud, pause;
    [SerializeField] private TextMeshProUGUI timeCount;
    [SerializeField] private List<GameObject> enemys;
    [SerializeField] private float timeStart, time;
    [SerializeField] private bool go = false, oneTime, start, isPaused;
    [SerializeField] Button skipVelocity;
    private Transform exitTransform;
    private PlayerMovement myMov;

    private AudioSource mySource, myMusic;
    [SerializeField] private AudioClip[] myClips;
    
    [SerializeField] private int scene;

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
        exitTransform = GameObject.FindGameObjectWithTag("Exit").GetComponent<Transform>();
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
            friend.ChangeTransform(exitTransform);
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

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            pause.SetActive(true);
            isPaused = true;
        }
        else if (isPaused)
        {
            Time.timeScale = 1;
            pause.SetActive(false);
            isPaused = false;
        }
    }
}

