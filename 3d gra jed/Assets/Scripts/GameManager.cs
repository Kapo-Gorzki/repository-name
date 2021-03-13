using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int timeToEnd;
    bool endGame = false;
    bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager = null)
        {
            gameManager = this;
        }
        if(timeToEnd <= 0)
        {
            timeToEnd = 30;
        }
        InvokeRepeating("Stopper", 2, 1);
    }
    public void EndGame()
    {
        CancelInvoke("Stopper");
        Debug.Log("EndGame");
    }

    // Update is called once per frame
    void Update()
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

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("timeToEnd: " + timeToEnd + "s");
        if(timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }
        if(endGame)
        {
            EndGame();  
        }
    }

    void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }
}
