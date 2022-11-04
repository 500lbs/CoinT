using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerCOPY : MonoBehaviour
{
    
    public SingletonStats ToolBoxRef;
    public TMPro.TMP_Text Player1Wins;
    public TMPro.TMP_Text Player1White;
    public TMPro.TMP_Text Player1Black;
    public TMPro.TMP_Text Player2Wins;
    public TMPro.TMP_Text Player2White;
    public TMPro.TMP_Text Player2Black;
    public TMPro.TMP_Text TotalFlippedText;
    public TMPro.TMP_Text Player1TurnText;
    public TMPro.TMP_Text Player2TurnText;
    public GameObject GameStart;
    public GameObject GamePlay;
    public GameObject GamePause;
    public GameObject GameEnd;
    public bool Paused = false;



    // Update is called once per frame
    void Update()
    {
        TotalFlippedText.text = "" + ToolBoxRef.TotalFlipped;

        Player1White.text = "" + ToolBoxRef.player1White;
        Player1Black.text = "" + ToolBoxRef.player1Black;
        Player2White.text = "" + ToolBoxRef.player2White;
        Player2Black.text = "" + ToolBoxRef.player2Black;
        if (ToolBoxRef.playerTurn == -1)
        {
            Player1TurnText.gameObject.SetActive(true);
            Player2TurnText.gameObject.SetActive(false);
        }
        else
        {
            Player2TurnText.gameObject.SetActive(true);
            Player1TurnText.gameObject.SetActive(false);
        }
        if (Paused)
        {
            GamePause.SetActive(true);

        }
        else
        {
            GamePause.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused = !Paused;
        }
    }

    /*public void RestartGame()
    {
        ToolBoxRef.Restart();
    }*/

}
