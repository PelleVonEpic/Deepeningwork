using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour {


    [SerializeField] private PlayerBoard player1Board;
    [SerializeField] private PlayerBoard player2Board;
    [SerializeField] private TurnHandler tHandler;
    [HideInInspector] private int relicsToBeRemoved;

    #region Getsetters
    
    public int RelicsToBeRemoved
    {
        get
        {
            return relicsToBeRemoved;
        }

        set
        {
            relicsToBeRemoved = value;
        }
    }

    #endregion

    public void PlayRelicToOwnBoard(Player caster, Relic relicToPlay)
    {
       
        if (caster == Player.Player1)
        {
            player1Board.CheckIfThereIsSpace();
            player1Board.PlayRelicToBoard(relicToPlay);

        }

        if (caster == Player.Player2)
        {
            player2Board.CheckIfThereIsSpace();
            player2Board.PlayRelicToBoard(relicToPlay);

        }
    }
    
    public void PlayEndOfTurnEffects(Player p)
    {
        if (p == Player.Player1)
        {
            player1Board.PlayEndOfTurnEffects();
        }
        if (p == Player.Player2)
        {
            player2Board.PlayEndOfTurnEffects();
        }
    }
    
    public void PlayStartOfTurnEffects(Player p)
    {
        if (p == Player.Player1)
        {
            player1Board.PlayStartOfTurnEffects();
        }
        if (p == Player.Player2)
        {
            player2Board.PlayStartOfTurnEffects();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
