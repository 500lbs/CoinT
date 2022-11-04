using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonStats : MonoBehaviour
{
    public static SingletonStats SingletonRef { get; set; }
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
