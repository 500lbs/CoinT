using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManagerS : MonoBehaviour
{
    #region Variables

    [Header("References")]

    [Header("Status / Main Screen")]
    public GameObject Player2TurnStatus;
    public GameObject Player1TurnStatus;

    [Header("Stats / Pause Screen")] 
    
    public int player1Wins;
    public int player1Black;
    public int player1White;

    public int player2Wins;
    public int player2Black;
    public int player2White;
    //-1 means player one / black & 1 means player two / white
    public int playerTurn = -1;
    public int coinChoise = -1;
    public int coinResult;
    public int TotalFlipped = 0;

    public bool canFlip = true;

    public TextMeshProUGUI Player1WinsText;
    public TextMeshProUGUI Player1BlackText;
    public TextMeshProUGUI Player1WhiteText;
    public TextMeshProUGUI Player2WinsText;
    public TextMeshProUGUI Player2BlackText;
    public TextMeshProUGUI Player2WhiteText;
    public TextMeshProUGUI TotalTimesFlippedText;

    [Header("Game Flow")]
    public bool StatsSwitch = false;
    public GameObject StatsObject;
    public bool GamePlaySwitch = true;
    public GameObject GamePlayObject;

    #endregion
    #region Basic Functions
    void Update()
    {
        UpdateStats();
        ToggleOverlayStats();
    }

    #endregion
    #region Stats Functions
    void UpdateStats()
    {
        //Player 1 Stats Update
        Player1WinsText.text = $"{player1Wins}";
        Player1BlackText.text = $"{player1Black}";
        Player1WhiteText.text = $"{player1White}";
        if (playerTurn == -1)
        {
            Player1TurnStatus.SetActive(true);
            Player2TurnStatus.SetActive(false);
        }
        //Player 2 Stats Update
        Player2WinsText.text = $"{player2Wins}";
        Player2BlackText.text = $"{player2Black}";
        Player2WhiteText.text = $"{player2White}";
        if (playerTurn != -1)
        {
            Player1TurnStatus.SetActive(false);
            Player2TurnStatus.SetActive(true);
        }

        TotalTimesFlippedText.text = $"{TotalFlipped}";
    }

    #endregion
    #region Game State Functions

    public void ToggleOverlayStats()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StatsSwitch = !StatsSwitch;
            GamePlaySwitch = !GamePlaySwitch;
        }
        if (StatsSwitch)
        {
            canFlip = false;
            StatsObject.SetActive(true);
            GamePlayObject.SetActive(false);
        }
        else
        {
            canFlip = true;
            StatsObject.SetActive(false);
            GamePlayObject.SetActive(true);
        }
    }
    public void Restart()
    {
        playerTurn = -1;
        coinChoise = -1;
        canFlip = true;
        TotalFlipped = 0;
        player1Wins = 0;
        player1White = 0;
        player1Black = 0;
        player2Wins = 0;
        player2White = 0;
        player2Black = 0;
    }
    public void StatsButton()
    {
        StatsSwitch = !StatsSwitch;
    }

    public void ClearStats()
    {
        playerTurn = -1;
        coinChoise = -1;
        canFlip = true;
        TotalFlipped = 0;
        player1Wins = 0;
        player1White = 0;
        player1Black = 0;
        player2Wins = 0;
        player2White = 0;
        player2Black = 0;
    }

    #endregion

}