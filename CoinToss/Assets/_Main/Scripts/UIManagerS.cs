using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerS : MonoBehaviour
{
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

    [Header("Switches")]
    public bool StatsSwitch = false;
    public GameObject StatsObject;
    public bool GamePlaySwitch = true;
    public GameObject GamePlayObject;

    void Update()
    {
        UpdateStats();
        ToggleOverlayStats();
    }

    void UpdateStats()
    {
        //Player 1 Stats Update
        Player1WinsText.text = $"{SingletonStats.SingletonRef.player1Wins}";
        Player1BlackText.text = $"{SingletonStats.SingletonRef.player1Black}";
        Player1WhiteText.text = $"{SingletonStats.SingletonRef.player1White}";
        if (SingletonStats.SingletonRef.playerTurn == -1)
        {
            Player1TurnStatus.SetActive(true);
            Player2TurnStatus.SetActive(false);
        }
        //Player 2 Stats Update
        Player2WinsText.text = $"{SingletonStats.SingletonRef.player2Wins}";
        Player2BlackText.text = $"{SingletonStats.SingletonRef.player2Black}";
        Player2WhiteText.text = $"{SingletonStats.SingletonRef.player2White}";
        if (SingletonStats.SingletonRef.playerTurn != -1)
        {
            Player1TurnStatus.SetActive(false);
            Player2TurnStatus.SetActive(true);
        }

        TotalTimesFlippedText.text = $"{SingletonStats.SingletonRef.TotalFlipped}";
    }

    public void ToggleOverlayStats()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StatsSwitch = !StatsSwitch;
            GamePlaySwitch = !GamePlaySwitch;
        }
        if (StatsSwitch)
        {
            SingletonStats.SingletonRef.canFlip = false;
            StatsObject.SetActive(true);
            GamePlayObject.SetActive(false);
        }
        else
        {
            SingletonStats.SingletonRef.canFlip = true;
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
        SingletonStats.SingletonRef.playerTurn = -1;
        SingletonStats.SingletonRef.coinChoise = -1;
        SingletonStats.SingletonRef.canFlip = true;
        SingletonStats.SingletonRef.TotalFlipped = 0;
        SingletonStats.SingletonRef.player1Wins = 0;
        SingletonStats.SingletonRef.player1White = 0;
        SingletonStats.SingletonRef.player1Black = 0;
        SingletonStats.SingletonRef.player2Wins = 0;
        SingletonStats.SingletonRef.player2White = 0;
        SingletonStats.SingletonRef.player2Black = 0;
    }
}