using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
        }
        else
        {
            Player = CurrentPlayer.PlayerOne;
        }
        DetermineEnemy();
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
	

	
	

}
