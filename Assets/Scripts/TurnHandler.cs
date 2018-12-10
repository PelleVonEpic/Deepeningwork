using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Player
{
    Player1,
    Player2

}


public class TurnHandler : MonoBehaviour {

    [HideInInspector] private enum CurrentPlayer
    {
        PlayerOne,
        PlayerTwo
    }
    [HideInInspector] public enum CurrentEnemy
    {
        PlayerOne,
        PlayerTwo
    }

    [SerializeField] private CurrentPlayer player;
    [SerializeField] private CurrentEnemy enemy;
    [SerializeField] private KeyCode changeTurnKey;
    [SerializeField] private Text turnText;

    #region Getsetters
    private CurrentPlayer Player
    {
        get
        {
            return player;
        }

        set
        {
            player = value;
        }
    }

    public CurrentEnemy Enemy
    {
        get
        {
            return enemy;
        }

        set
        {
            enemy = value;
        }
    }

    #endregion

    public void ChangePlayerTurn()
    {
        if (Player == CurrentPlayer.PlayerOne)
        {
            Player = CurrentPlayer.PlayerTwo;
            turnText.text = "Currently Player One";

        }
        else
        {
            Player = CurrentPlayer.PlayerOne;
            turnText.text = "Currently Player Two";

        }

    }

    public void DetermineEnemy()
    {
        if (Player == CurrentPlayer.PlayerOne)
        {
            Enemy = CurrentEnemy.PlayerTwo;
        }
        else
        {
            Enemy = CurrentEnemy.PlayerOne;
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

    }

}
