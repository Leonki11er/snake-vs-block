using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatement : MonoBehaviour
{
    public enum State
    {
        Playing,
        Won,
        Loss,
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
