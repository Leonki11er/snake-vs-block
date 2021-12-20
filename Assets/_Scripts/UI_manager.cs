using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{

    public GameStatement GameStatement;
    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject PausePanel;
    public GameObject MainMenu;
    public Text CurrentScore;
    public Text BestScoreMM;
    public Text BestScoreLP;
    public Text BestScoreWP;
    public Text ScoreLP;
    public Text ScoreWP;
    public Button ResumeGameButton;

    public void ActivePanel(GameObject panel, bool state)
    {
        panel.SetActive(state);
        
    }
    
    public void SetText(Text text, int value)
    {
        text.text = value.ToString();
    }
}
