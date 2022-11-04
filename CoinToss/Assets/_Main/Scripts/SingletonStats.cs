using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonStats : MonoBehaviour
{
    public static SingletonStats SingletonRef { get; set; }

    [Header("P1 Stats")]
    public int player1Wins;
    public int player1Black;
    public int player1White;

    [Header("P1 Stats")]
    public int player2Wins;
    public int player2Black;
    public int player2White;

    [Header("Game Stat(u)s")]
    public int playerTurn = -1; //-1 means player one and black
    public int coinChoise = -1; //+1 means player two and white
    public int coinResult;
    public int TotalFlipped = 0;
    public bool canFlip = true;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (SingletonRef == null)
        {
            SingletonRef = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
