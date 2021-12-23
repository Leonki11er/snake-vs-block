using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatement : MonoBehaviour
{
    public GameObject Player;
    public UI_manager UI_Manager;
    public int StartLength;
    
    public enum State
    {
        Playing,
        Won,
        Loss,
        Pause,
    }
    public State CurrentState { get; private set; }
    public int LevelLength;
    private const string SnakeLength = "SnakeLength";
    public int Snake_Length
    {
        get => PlayerPrefs.GetInt(SnakeLength, 0);
        private set
        {
            PlayerPrefs.SetInt(SnakeLength, value);
            PlayerPrefs.Save();
        }
    }

    private const string _score = "Score";
    public int Score
    {
        get => PlayerPrefs.GetInt(_score, 0);
        private set
        {
            PlayerPrefs.SetInt(_score, value);
            PlayerPrefs.Save();
        }
    }

    private const string _bestScore = "BestScore";
    public int BestScore
    {
        get => PlayerPrefs.GetInt(_bestScore, 0);
        private set
        {
            PlayerPrefs.SetInt(_bestScore, value);
            PlayerPrefs.Save();
        }
    }

    private void Awake()
    {
        UI_Manager.SetText(UI_Manager.CurrentScore, Score);
    }

    public void SetSnakeLength(int mass)
    {
        Snake_Length = mass;
    }
    
    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss; 
        Player.SetActive(false);
        UI_Manager.SetText(UI_Manager.ScoreLP, Score);
        UI_Manager.SetText(UI_Manager.BestScoreLP, BestScore);
        UI_Manager.ActivePanel(UI_Manager.LosePanel,true);
        Snake_Length = StartLength;
        Score = 0;
    }

    public void OnPlayerReachFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        Player.SetActive(false);
        UI_Manager.SetText(UI_Manager.ScoreWP, Score);
        UI_Manager.SetText(UI_Manager.BestScoreWP, BestScore);
        UI_Manager.ActivePanel(UI_Manager.WinPanel,true);
    }

    public void PauseGame()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Pause;
        Player.SetActive(false);
        Time.timeScale = 0f;
        UI_Manager.ActivePanel(UI_Manager.PausePanel, true);

    }

    public void ResumeGame()
    {
        if (CurrentState != State.Pause) return;
        CurrentState = State.Playing;
        Player.SetActive(true);
        Time.timeScale = 1f;
        UI_Manager.ActivePanel(UI_Manager.PausePanel, false);
    }

    public void NewGame()
    {
        Score = 0;
        ReloadLevel();
    }

    public void ScoreIncrement()
    {
        Score++;
        if (BestScore < Score)
        {
            BestScore = Score;
        }
        UI_Manager.SetText(UI_Manager.CurrentScore, Score);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void OnApplicationQuit()
    {
        Score = 0;
        Snake_Length = StartLength;
    }
}
