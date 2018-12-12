using System.Collections;
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
    [SerializeField] private int turnCount = 0;
    [SerializeField] private int turnCountTracker = 0;


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
        }
        else //Otherwise change to player one
        {
            CurrentPlayer = Player.Player1;
            turnText.text = "Currently Player One";
            turnImage.color = Color.magenta;
        }

    }
	
    void Update()
    {
        if (Input.GetKeyDown(changeTurnKey))
        {
            ChangePlayerTurn();
        }
        
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
    }

}
