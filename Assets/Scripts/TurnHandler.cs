﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Player
{
    Player1,
    Player2

}

public class TurnHandler : MonoBehaviour
{
    
    [SerializeField] private Player currentPlayer;
    [SerializeField] private KeyCode changeTurnKey;
    [SerializeField] private Text turnText;
    [SerializeField] private Image turnImage;
    [SerializeField] private Text turnCounterText;
    [SerializeField] private ResourceHandler rHandler;
    [SerializeField] private Hand player1Hand;
    [SerializeField] private Hand Player2Hand;
    [HideInInspector] private int turnCount = 1;
    [HideInInspector] private int turnCountTracker = 0;


    #region Getsetters
    public Player CurrentPlayer
    {
        get
        {
            return currentPlayer;
        }

        set
        {
            currentPlayer = value;
        }
    }
    #endregion

    public void ChangePlayerTurn()
    {
        if (CurrentPlayer == Player.Player1) //If currently player one, change to player two
        {
            CurrentPlayer = Player.Player2;
            turnText.text = "Currently Player Two";
            turnImage.color = Color.cyan;
            rHandler.Player2Energy = turnCount;
            Player2Hand.DrawCard();
        }
        else //Otherwise change to player one
        {
            CurrentPlayer = Player.Player1;
            turnText.text = "Currently Player One";
            turnImage.color = Color.magenta;
            rHandler.Player1Energy = turnCount;
            player1Hand.DrawCard();
        }

        //Increase turnCount every other turn
        turnCountTracker += 1;
        if (turnCountTracker >= 2)
        {
            turnCountTracker = 0;
            turnCount += 1;
        }
        rHandler.UpdateEnergy();
    }
	
    void Update()
    {
        if (Input.GetKeyDown(changeTurnKey))
        {
            ChangePlayerTurn();
        }
        
    }

    private IEnumerator DrawOpeningHands()
    {

        yield return new WaitForSeconds(1);

        //Draw Starting hands
        for (int i = 0; i < 3; i++)
        {
            player1Hand.DrawCard();
            Debug.Log("Hello!");
        }
        for (int i = 0; i < 3; i++)
        {
            Player2Hand.DrawCard(); Debug.Log("Hello! 2!");

        }
        Debug.Log("Blupp");

    }

    void Start()
    {
        //Randomize starting player
        int r = Random.Range(1, 3);
        if (r == 1)
        {
            currentPlayer = Player.Player1;
            turnText.text = "Currently Player One";
            turnImage.color = Color.magenta;
        }
        else
        {
            currentPlayer = Player.Player2;
            turnText.text = "Currently Player Two";
            turnImage.color = Color.cyan;
        }

        StartCoroutine( DrawOpeningHands());

        //Make sure to count the first turn
        turnCountTracker += 1;
        turnCounterText.text = turnCount.ToString();
    }

}
