using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManagerS : MonoBehaviour
{
    [Header("Stats / Pause Screen")]
    [SerializeField] private GameObject _statsMenu;
    [SerializeField] private TextMeshProUGUI _player1Wins;
    [SerializeField] private TextMeshProUGUI _player1Black;
    [SerializeField] private TextMeshProUGUI _player1White;

    [SerializeField] private TextMeshProUGUI _player2Wins;
    [SerializeField] private TextMeshProUGUI _player2Black;
    [SerializeField] private TextMeshProUGUI _player2White;

    [SerializeField] private GameObject _player2TurnStatus;
    [SerializeField] private GameObject _player1TurnStatus;

    [Header("References")]
    [SerializeField] private Toolbox ToolBoxRef;

    #region Basic Functions
    void Update()
    {
        Player1Wins();
        Player2Wins();

        Player1Guess();
        Player2Guess();

        TotalFlipped();
        CheckStatus();
    }

    #endregion
    #region Stats
    void Player1Wins()
    {
        _player1Wins.text = $"{ToolBoxRef.player1Wins}";
    }

    void Player2Wins()
    {
        _player1Wins.text = $"{ToolBoxRef.player2Wins}";
    }

    void Player1GuessBlack()
    {
        _player1Black.text = $"{ToolBoxRef.player1Black}";
    }

    void Player1GuessWhite()
    {
        _player1White.text = $"{ToolBoxRef.player1White}";
    }

    void Player1Guess()
    {
        _player1Black.text = $"{ToolBoxRef.player1Black}";
        _player1White.text = $"{ToolBoxRef.player1White}";
    }


    void Player2Guess()
    {
        _player2Black.text = $"{ToolBoxRef.player2Black}";
        _player2White.text = $"{ToolBoxRef.player2White}";
    }

    void CheckStatus()
    {
        if (ToolBoxRef.playerTurn == -1)
        {
            _player1TurnStatus.SetActive(true);
            _player2TurnStatus.SetActive(false);
        }

        if (ToolBoxRef.playerTurn != -1)
        {
            _player1TurnStatus.SetActive(false);
            _player2TurnStatus.SetActive(true);
        }
    }

    void TotalFlipped()
    {
    }
    #endregion

    /*
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        _statsMenu.SetActive(true);
    }
    */

}