using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Toolbox ToolBoxRef;

    // Update is called once per frame
    void Update()
    {
        Player1Guess();
        Player2Guess();
        TotalFlipped();     
    }

    void Player1Guess()
    {
        /* UPDATE UGUI WITH:
         * public int player1Wins;
         * public int player1Black;
         * public int player1White;
        */
    }

    void Player2Guess()
    {
        /* UPDATE UGUI WITH:
         * public int player2Wins;
         * public int player2Black;
         * public int player2White;
        */
    }

    void CheckStatus()
    {
        /* UPDATE UGUI WITH:
         * Who's turn it is
        */
    }
    void TotalFlipped()
    {
        // How many times has the coin been flipped?
    }

}
