using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManagerS : MonoBehaviour
{
    #region Variables
    [Header("References")]
    public Toolbox ToolBoxRef;

    [Header("Status / Main Screen")]
    public GameObject Player2TurnStatus;
    public GameObject Player1TurnStatus;

    [Header("Stats / Pause Screen")]
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
        Player1WinsText.text = $"{ToolBoxRef.player1Wins}";
        Player1BlackText.text = $"{ToolBoxRef.player1Black}";
        Player1WhiteText.text = $"{ToolBoxRef.player1White}";
        if (ToolBoxRef.playerTurn == -1)
        {
            Player1TurnStatus.SetActive(true);
            Player2TurnStatus.SetActive(false);
        }
        //Player 2 Stats Update
        Player2WinsText.text = $"{ToolBoxRef.player2Wins}";
        Player2BlackText.text = $"{ToolBoxRef.player2Black}";
        Player2WhiteText.text = $"{ToolBoxRef.player2White}";
        if (ToolBoxRef.playerTurn != -1)
        {
            Player1TurnStatus.SetActive(false);
            Player2TurnStatus.SetActive(true);
        }

        TotalTimesFlippedText.text = $"{ToolBoxRef.TotalFlipped}";
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
            StatsObject.SetActive(true);
            GamePlayObject.SetActive(false);
        }
        else
        {
            StatsObject.SetActive(false);
            GamePlayObject.SetActive(true);
        }
    }

    public void StatsButton()
    {
        StatsSwitch = !StatsSwitch;
    }

    public void ClearStats()
    {
        ToolBoxRef.playerTurn = -1;
        ToolBoxRef.coinChoise = -1;
        ToolBoxRef.canFlip = true;
        ToolBoxRef.TotalFlipped = 0;
        ToolBoxRef.player1Wins = 0;
        ToolBoxRef.player1White = 0;
        ToolBoxRef.player1Black = 0;
        ToolBoxRef.player2Wins = 0;
        ToolBoxRef.player2White = 0;
        ToolBoxRef.player2Black = 0;
    }
    #endregion

}