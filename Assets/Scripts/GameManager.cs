using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor
{
    Red,
    Green, 
    Gold
}

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public bool gamePaused;
    public AudioClip resumeClip;
    public AudioClip pauseClip;
    public AudioClip winClip;
    public AudioClip looseClip;
    AudioSource audioSource;
    bool endGame = false;
    bool win = false;

    public int points = 0;
    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;

    [SerializeField] int timeToEnd;

    // Start is called before the first frame update
    void Start()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating(nameof(Stopper), 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
        KeyCheck();
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    void Stopper()
    {
        timeToEnd--;
        if(timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
            EndGame();
        }
        Debug.Log($"Time: {timeToEnd} s");
    }

    public void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
        PlayClip(pauseClip);
    }

    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
        PlayClip(resumeClip);
    }

    void PauseCheck()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void EndGame()
    {
        CancelInvoke(nameof(Stopper));
        if(win)
        {
            PlayClip(winClip);
            Debug.Log("You win");
        }
        else
        {
            PlayClip(looseClip);
            Debug.Log("You lose");
        }
    }

    public void AddPoints(int point)
    {
        points += point;
        if(points >= 10)
        {
            win = true;
        }
    }

    public void AddTime(int addTime)
    {
        timeToEnd += addTime;
    }

    public void FreezeTime(int freeze)
    {
        CancelInvoke(nameof(Stopper));
        InvokeRepeating(nameof(Stopper), freeze, 1);
    }

    public void AddKey(KeyColor color)
    {
        if(color == KeyColor.Red)
        {
            redKey++;
        } 
        else if(color == KeyColor.Green)
        {
            greenKey++;
        }
        else if(color == KeyColor.Gold)
        {
            goldKey++;
        }
    }

    public void KeyCheck()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log($"You have {redKey} red keys, {greenKey} green Keys, {goldKey} gold Keys");
        }
    }
}
