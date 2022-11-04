using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Stats / Pause Screen")]
    [SerializeField] private GameObject _statsMenu;
    [SerializeField] private TextMeshProUGUI _player1Wins;
    [SerializeField] private TextMeshProUGUI _player1Black;
    [SerializeField] private TextMeshProUGUI _player1White;

    [SerializeField] private TextMeshProUGUI _player2Wins;
    [SerializeField] private TextMeshProUGUI _player2Black;
    [SerializeField] private TextMeshProUGUI _player2White;

    [Header("References")]
    public UIManagerS ToolBoxRef;

    #region Basic Functions
    void Update()
    {
        Player1Guess();
        Player2Guess();
        TotalFlipped();     
    }

    #endregion
    #region Stats
    void Player1Guess()
    {
        _player1Wins.text = $"{ToolBoxRef.player1Wins}";
    }

    void Player2Guess()
    {
    }

    void CheckStatus()
    {
    }
    void TotalFlipped()
    {
    }
    #endregion

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        _statsMenu.SetActive(true);
    }

}