using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatement : MonoBehaviour
{
    public GameObject Player;
    public UI_manager UI_Manager;
    public enum State
    {
        Playing,
        Won,
        Loss,
        Pause,
    }
    public State CurrentState { get; private set; }

    private const string LevelIndexKey = "LevelIndex";
    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
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

    //private void Awake()
    //{
    //    Score = 0;
    //    UI_Manager.ActivePanel(UI_Manager.MainMenu, true);
    //    UI_Manager.SetText(UI_Manager.BestScoreMM, BestScore);
    //    if(Score == 0) UI_Manager.ResumeGameButton.gameObject.SetActive(false);
    //    Debug.Log(Score);
    //    Player.SetActive(false);
    //}

    public void buttonSwitch()
    {
        UI_Manager.ResumeGameButton.gameObject.SetActive(true);
    }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss; 
        Player.SetActive(false);
        UI_Manager.SetText(UI_Manager.ScoreLP, Score);
        UI_Manager.SetText(UI_Manager.BestScoreLP, BestScore);
        UI_Manager.ActivePanel(UI_Manager.LosePanel,true);
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
        LevelIndex++;
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
}
