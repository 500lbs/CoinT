using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
 

    public Animator animCoin;

    private float randomNumber;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        randomNumber = Random.Range(-10f, 10f);
        if (Input.GetKeyDown(KeyCode.Space) && SingletonStats.SingletonRef.canFlip == true)
        {
            FlipCoin();
        }

        if (SingletonStats.SingletonRef.playerTurn == -1 && Input.GetKeyUp(KeyCode.E) && SingletonStats.SingletonRef.canFlip == true)
        {
            SingletonStats.SingletonRef.canFlip = false;
            Invoke("BlackSide", 0.05f);
            animCoin.SetBool("ChangeToBlack", true);
        }

        else if (SingletonStats.SingletonRef.playerTurn == -1 && Input.GetKeyUp(KeyCode.Q) && SingletonStats.SingletonRef.canFlip == true)
        {
            SingletonStats.SingletonRef.canFlip = false;
            Invoke("WhiteSide", 0.05f);
            animCoin.SetBool("ChangeToWhite", true);
        }

        if (SingletonStats.SingletonRef.playerTurn == 1 && Input.GetKeyUp(KeyCode.U) && SingletonStats.SingletonRef.canFlip == true)
        {
            SingletonStats.SingletonRef.canFlip = false;
            Invoke("WhiteSide", 0.05f);
            animCoin.SetBool("ChangeToWhite", true);
        }
        else if (SingletonStats.SingletonRef.playerTurn == 1 && Input.GetKeyUp(KeyCode.O) && SingletonStats.SingletonRef.canFlip == true)
        {
            SingletonStats.SingletonRef.canFlip = false;
            Invoke("BlackSide", 0.05f);
            animCoin.SetBool("ChangeToBlack", true);
        }
        //ChooseTurn();
    }

    public void BlackSide()
    {
        SingletonStats.SingletonRef.canFlip = true;
        SingletonStats.SingletonRef.coinChoise = -1;
        animCoin.SetBool("ChangeToBlack", false);
    }

    public void WhiteSide()
    {
        SingletonStats.SingletonRef.canFlip = true;
        SingletonStats.SingletonRef.coinChoise = 1;
        animCoin.SetBool("ChangeToWhite", false);
    }

    void CollectPoint1()
    {
        SingletonStats.SingletonRef.player1Wins++;
        if (SingletonStats.SingletonRef.coinResult == -1)
        {
            SingletonStats.SingletonRef.player1Black++;
        }
        else if (SingletonStats.SingletonRef.coinResult == 1)
        {
            SingletonStats.SingletonRef.player1White++;
        }
    }

    void CollectPoint2()
    {
        SingletonStats.SingletonRef.player2Wins++;
        if (SingletonStats.SingletonRef.coinResult == -1)
        {
            SingletonStats.SingletonRef.player2Black++;
        }
        else if (SingletonStats.SingletonRef.coinResult == 1)
        {
            SingletonStats.SingletonRef.player2White++;
        }
    }

    void FlipCoin()
    {
        SingletonStats.SingletonRef.canFlip = false;
        if (randomNumber > 0)
        {
            animCoin.SetBool("FlipBlack", true);
            SingletonStats.SingletonRef.coinResult = -1;
        }
        else if (randomNumber <= 0)
        {
            animCoin.SetBool("FlipWhite", true);
            SingletonStats.SingletonRef.coinResult = 1;
        }
        if (SingletonStats.SingletonRef.coinChoise == SingletonStats.SingletonRef.coinResult)
        {
            if (SingletonStats.SingletonRef.playerTurn == -1)
            {
                CollectPoint1();
            }
            else if (SingletonStats.SingletonRef.playerTurn == 1)
            {
                CollectPoint2();
            }
        }
        SingletonStats.SingletonRef.TotalFlipped++;
        Invoke("EndTurn", 1.3f);
    }

    void EndTurn()
    {
        SingletonStats.SingletonRef.playerTurn = -SingletonStats.SingletonRef.playerTurn;
        animCoin.SetBool("FlipWhite", false);
        animCoin.SetBool("FlipBlack", false);
        SingletonStats.SingletonRef.canFlip = true;
    }
}
