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

    #region Getsetters

    #endregion

    public void ChangePlayerTurn()
    {
        if (CurrentPlayer == Player.Player1)
        {
            CurrentPlayer = Player.Player2;
            turnText.text = "Currently Player Two";
            turnImage.color = Color.cyan;

        }
        else
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
        turnText.text = "Currently Player One";
        turnImage.color = Color.magenta;

    }

}
