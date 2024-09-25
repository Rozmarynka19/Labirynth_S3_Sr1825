using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField]
    int timeToEnd;

    bool isGamePaused = false;
    [SerializeField]
    KeyCode pauseKey = KeyCode.P;

    bool endGame = false;
    bool win = false;

    private void Start()
    {
        if (gameManager == null)
            gameManager = this;
        else
            Destroy(this);

        Time.timeScale = 1f;

        if (timeToEnd <= 0)
        {
            timeToEnd = 100;
        }

        InvokeRepeating(nameof(Timer), 2f, 1f);
    }

    private void Update()
    {
        PauseCheck();
    }

    void Timer()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd}");

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
            win = false;
        }

        if (endGame)
        {
            EndGame();
        }
    }

    void PauseCheck()
    {
        if (!Input.GetKeyDown(pauseKey)) return;

        if (isGamePaused)
            ResumeGame();
        else
            PauseGame();
    }

    void PauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void EndGame()
    {
        CancelInvoke(nameof(Timer));

        Time.timeScale = 0f;

        if (win)
            Debug.Log("You win!");
        else
            Debug.Log("You lose!");
    }
}
