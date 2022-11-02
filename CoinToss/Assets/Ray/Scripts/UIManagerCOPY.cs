using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerCOPY : MonoBehaviour
{
    public Toolbox ToolBoxRef;
    public TMPro.TMP_Text Player1Wins;
    public TMPro.TMP_Text Player1White;
    public TMPro.TMP_Text Player1Black;
    public TMPro.TMP_Text Player2Wins;
    public TMPro.TMP_Text Player2White;
    public TMPro.TMP_Text Player2Black;
    public TMPro.TMP_Text TotalFlippedText;

    // Update is called once per frame
    void Update()
    {
        TotalFlippedText.text = "" + ToolBoxRef.TotalFlipped;

        Player1White.text = "" + ToolBoxRef.player1White;
        Player1Black.text = "" + ToolBoxRef.player1Black;
        Player2White.text = "" + ToolBoxRef.player2White;
        Player2Black.text = "" + ToolBoxRef.player2Black;
    }


}
