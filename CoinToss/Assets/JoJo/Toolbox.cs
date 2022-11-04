using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    public UIManagerS UIManagerRef;

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
        if (Input.GetKeyDown(KeyCode.Space) && UIManagerRef.canFlip == true)
        {
            FlipCoin();
        }

        if (UIManagerRef.playerTurn == -1 && Input.GetKeyUp(KeyCode.E) && UIManagerRef.canFlip == true)
        {
            UIManagerRef.canFlip = false;
            Invoke("BlackSide", 0.05f);
            animCoin.SetBool("ChangeToBlack", true);
        }

        else if (UIManagerRef.playerTurn == -1 && Input.GetKeyUp(KeyCode.Q) && UIManagerRef.canFlip == true)
        {
            UIManagerRef.canFlip = false;
            Invoke("WhiteSide", 0.05f);
            animCoin.SetBool("ChangeToWhite", true);
        }

        if (UIManagerRef.playerTurn == 1 && Input.GetKeyUp(KeyCode.U) && UIManagerRef.canFlip == true)
        {
            UIManagerRef.canFlip = false;
            Invoke("WhiteSide", 0.05f);
            animCoin.SetBool("ChangeToWhite", true);
        }
        else if (UIManagerRef.playerTurn == 1 && Input.GetKeyUp(KeyCode.O) && UIManagerRef.canFlip == true)
        {
            UIManagerRef.canFlip = false;
            Invoke("BlackSide", 0.05f);
            animCoin.SetBool("ChangeToBlack", true);
        }
        //ChooseTurn();
    }

    public void BlackSide()
    {
        UIManagerRef.canFlip = true;
        UIManagerRef.coinChoise = -1;
        animCoin.SetBool("ChangeToBlack", false);
    }

    public void WhiteSide()
    {
        UIManagerRef.canFlip = true;
        UIManagerRef.coinChoise = 1;
        animCoin.SetBool("ChangeToWhite", false);
    }

    void CollectPoint1()
    {
        UIManagerRef.player1Wins++;
        if (UIManagerRef.coinResult == -1)
        {
            UIManagerRef.player1Black++;
        }
        else if (UIManagerRef.coinResult == 1)
        {
            UIManagerRef.player1White++;
        }
    }

    void CollectPoint2()
    {
        UIManagerRef.player2Wins++;
        if (UIManagerRef.coinResult == -1)
        {
            UIManagerRef.player2Black++;
        }
        else if (UIManagerRef.coinResult == 1)
        {
            UIManagerRef.player2White++;
        }
    }

    void FlipCoin()
    {
        UIManagerRef.canFlip = false;
        if (randomNumber > 0)
        {
            animCoin.SetBool("FlipBlack", true);
            UIManagerRef.coinResult = -1;
        }
        else if (randomNumber <= 0)
        {
            animCoin.SetBool("FlipWhite", true);
            UIManagerRef.coinResult = 1;
        }
        if (UIManagerRef.coinChoise == UIManagerRef.coinResult)
        {
            if (UIManagerRef.playerTurn == -1)
            {
                CollectPoint1();
            }
            else if (UIManagerRef.playerTurn == 1)
            {
                CollectPoint2();
            }
        }
        UIManagerRef.TotalFlipped++;
        Invoke("EndTurn", 1.3f);
    }

    void EndTurn()
    {
        UIManagerRef.playerTurn = -UIManagerRef.playerTurn;
        animCoin.SetBool("FlipWhite", false);
        animCoin.SetBool("FlipBlack", false);
        UIManagerRef.canFlip = true;
    }
}
