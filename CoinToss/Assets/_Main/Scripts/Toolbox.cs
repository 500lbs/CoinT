using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    public Animator animCoin;
    private float randomNumber;
    public float time = 3f;
    public float timer;

    void Start()
    {
        timer = Time.time;
    }

    void Update()
    {
        KeyDelay();
        ChooseFlip();
    }
    void KeyDelay()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SingletonStats.SingletonRef.canFlip = true;
                timer = 0;
            }
        }
        else
        {
            SingletonStats.SingletonRef.canFlip = false;
        }
    }
    public void ChooseFlip()
    {
        randomNumber = Random.Range(-10f, 10f);
        if (Input.GetKeyDown(KeyCode.Space) && SingletonStats.SingletonRef.canFlip == true)
        {
            AnimateCoin();
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

    void AnimateCoin()
    {
        //SingletonStats.SingletonRef.canFlip = false;
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
        StartCoroutine(EndTurn());
    }

    IEnumerator EndTurn()
    {
        yield return new WaitForSeconds(0.5f);
        SingletonStats.SingletonRef.playerTurn = -SingletonStats.SingletonRef.playerTurn;
        animCoin.SetBool("FlipWhite", false);
        animCoin.SetBool("FlipBlack", false);
        SingletonStats.SingletonRef.canFlip = true;
    }
}
